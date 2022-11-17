import React, { useEffect, useState } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import Img64Base from "../utils/Img64Base";

const Cart = () => {
	const { CallApi: GetItemsInCart, data: itemsInCart } = useAuthFetch();
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
		[isUpdatingEntry]
	);

	useEffect(() => {
		console.log(wasValidAmount);
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
		//setServerItemAmounts(itemAmounts);
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
						<h5>Hello</h5>
						<p>{it.name}</p>
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
						<p>{it.amount}</p>
						<p>{it.price}</p>
						<p>{it.price * it.amount}</p>
					</div>
				);
			})}
			<button>Kupuję</button>
		</div>
	);
};

export default Cart;
