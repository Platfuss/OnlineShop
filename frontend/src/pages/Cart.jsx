//TODO: alert with not enough items pops up to often
import React, { useEffect, useState } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import Img64Base from "../utils/Img64Base";
import { useNavigate, NavLink } from "react-router-dom";
import useAuth from "../utils/useAuth";
import PropagateLoader from "react-spinners/PropagateLoader";
import { useRef } from "react";
import ErrorMessageBox from "../components/ErrorMessageBox";

const Cart = () => {
	const Navigate = useNavigate();

	const triedToCreateOrder = useRef(false);

	const { setCartTotal } = useAuth();

	const [itemAmounts, setItemAmounts] = useState({});

	let validationBody = [];
	for (const [key, value] of Object.entries(itemAmounts)) {
		validationBody.push({ itemId: key, Amount: value });
	}
	validationBody = JSON.stringify(validationBody);

	const {
		CallApi: GetItemsInCart,
		data: itemsInCart,
		isLoading: isItemsInCartLoading,
	} = useAuthFetch();

	const { CallApi: DeleteItemFromCart, isLoading: isDeletingEntry } =
		useAuthFetch();

	const {
		CallApi: GetCartTotalPrice,
		data: cartTotalPrice,
		isLoading: isUpdatingTotalPrice,
	} = useAuthFetch();

	const {
		CallApi: ValidateCart,
		data: validationResponse,
		isLoading: isValidating,
	} = useAuthFetch();

	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => GetItemsInCart("carts/get", METHOD.GET), []);

	useEffect(
		() => {
			if (isDeletingEntry === false && isValidating === false) {
				GetItemsInCart("carts/get", METHOD.GET);
				GetCartTotalPrice("carts/total-price", METHOD.GET);
			}
		},
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[isDeletingEntry, isValidating]
	);

	useEffect(() => {
		if (cartTotalPrice === 0 || cartTotalPrice) {
			setCartTotal(cartTotalPrice);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [cartTotalPrice]);

	useEffect(() => {
		let itemAmounts = {};
		if (itemsInCart) {
			for (const itemIndex in itemsInCart) {
				var item = itemsInCart[itemIndex];
				itemAmounts[item.itemId] = item.amount;
			}
		}
		setItemAmounts(itemAmounts);
	}, [itemsInCart]);

	useEffect(() => {
		if (
			validationResponse?.success === true &&
			isUpdatingTotalPrice === false
		) {
			if (triedToCreateOrder.current === true) {
				Navigate("/create-order");
			}
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isUpdatingTotalPrice]);

	const EnforceMinMax = (entryNumber, min, max) => {
		var outputNumber = Number(entryNumber ? entryNumber : 0).toString();
		if (outputNumber < min) {
			return min;
		} else if (outputNumber > max) {
			return max;
		}
		return outputNumber;
	};

	return (
		<div>
			<PropagateLoader
				loading={isItemsInCartLoading && !itemsInCart?.length}
			/>

			{itemsInCart && (
				<div className="cart">
					<h1>Koszyk</h1>
					{validationResponse?.success === false && (
						<ErrorMessageBox
							lackingItems={validationResponse.items}
						></ErrorMessageBox>
					)}
					{itemsInCart?.length ? (
						<div className="tableContainer">
							<table>
								<thead>
									<tr>
										<th></th>
										<th>Produkt</th>
										<th>Cena</th>
										<th>Ilość</th>
										<th>Wartość</th>
										<th></th>
									</tr>
								</thead>
								<tbody>
									{itemsInCart?.map((it) => {
										return (
											<tr key={it.itemId}>
												<td>
													<Img64Base src={it.image}></Img64Base>
												</td>

												<td>
													<NavLink
														end
														to={`/products/details/${it.itemId}`}
													>
														{it.name}
													</NavLink>
												</td>

												<td>
													{new Intl.NumberFormat("pl-PL", {
														style: "currency",
														currency: "PLN",
													}).format(it.price)}
												</td>
												<td>
													<input
														type={"number"}
														min={0}
														max={999}
														value={EnforceMinMax(
															itemAmounts[it.itemId],
															0,
															999
														)}
														onChange={(e) => {
															var newAmounts = {
																...itemAmounts,
																[it.itemId]: parseInt(
																	e.target.value
																),
															};
															setItemAmounts(newAmounts);
														}}
													></input>
												</td>

												<td>
													{new Intl.NumberFormat("pl-PL", {
														style: "currency",
														currency: "PLN",
													}).format(it.price * it.amount)}
												</td>

												<td>
													<button
														onClick={() =>
															DeleteItemFromCart(
																`carts/${it.itemId}`,
																METHOD.DELETE
															)
														}
													>
														X
													</button>
												</td>
											</tr>
										);
									})}
								</tbody>
							</table>

							<button
								onClick={() => {
									triedToCreateOrder.current = false;
									ValidateCart(
										"carts/validate",
										METHOD.POST,
										validationBody
									);
								}}
							>
								Przelicz
							</button>

							<button
								onClick={() => {
									triedToCreateOrder.current = true;
									ValidateCart(
										"carts/validate",
										METHOD.POST,
										validationBody
									);
								}}
							>
								Zamawiam
							</button>
						</div>
					) : (
						<>
							<h3>Twój koszyk jest pusty</h3>
							<button onClick={() => Navigate(-1)}>Powrót</button>
						</>
					)}
				</div>
			)}
		</div>
	);
};

export default Cart;
