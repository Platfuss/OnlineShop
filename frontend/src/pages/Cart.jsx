import React, { useEffect, useState } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import Img64Base from "../utils/Img64Base";
import { useNavigate, NavLink } from "react-router-dom";

const Cart = () => {
	const Navigate = useNavigate();
	const { CallApi: GetItemsInCart, data: itemsInCart } = useAuthFetch();
	const { CallApi: DeleteItemFromCart, isLoading: isDeletingEntry } =
		useAuthFetch();
	const {
		CallApi: UpdateEntry,
		isLoading: isUpdatingEntry,
		data: wasValidAmount,
	} = useAuthFetch();
	//const [serverItemAmounts, setServerItemAmounts] = useState({});
	const [webItemAmounts, setWebItemAmounts] = useState({});

	useEffect(
		() => GetItemsInCart("carts/get", METHOD.GET),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	useEffect(
		() => {
			if (isUpdatingEntry || isDeletingEntry === false) {
				GetItemsInCart("carts/get", METHOD.GET);
			}
		},
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[isUpdatingEntry, isDeletingEntry]
	);

	useEffect(() => {
		if (wasValidAmount === false)
			alert("Przekroczono liczbę dostępnych produktów");
	}, [wasValidAmount]);

	useEffect(() => {
		let itemAmounts = {};
		if (itemsInCart) {
			for (const itemIndex in itemsInCart) {
				var item = itemsInCart[itemIndex];
				itemAmounts[item.itemId] = item.amount;
			}
		}
		setWebItemAmounts(itemAmounts);
	}, [itemsInCart]);

	const OnAmountConfirmed = (itemId) => {
		UpdateEntry(
			"carts/update",
			METHOD.PATCH,
			JSON.stringify({
				itemId: itemId,
				amount: webItemAmounts[itemId],
			})
		);
	};

	return (
		<div className="wholePage">
			{itemsInCart?.map((it) => {
				return (
					<div key={it.itemId}>
						<Img64Base
							className="singleProductImage"
							src={it.image}
						></Img64Base>
						<NavLink end to={`/products/details/${it.itemId}`}>
							{it.name}
						</NavLink>
						<input
							type={"number"}
							min={0}
							max={99}
							value={webItemAmounts[it.itemId] || 0}
							onBlur={() => OnAmountConfirmed(it.itemId)}
							onChange={(e) => {
								var newAmounts = {
									...webItemAmounts,
									[it.itemId]: parseInt(e.target.value),
								};
								setWebItemAmounts(newAmounts);
							}}
						></input>
						<button
							onClick={() =>
								DeleteItemFromCart(`carts/${it.itemId}`, METHOD.DELETE)
							}
						>
							X
						</button>
						<p>{it.amount}</p>
						<p>{it.price}</p>
						<p>{it.price * it.amount}</p>
					</div>
				);
			})}
			<button
				disabled={Object.keys(webItemAmounts).length === 0}
				onClick={() => Navigate("/create-order")}
			>
				Zamawiam
			</button>
		</div>
	);
};

export default Cart;
