import React, { useEffect } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";

//TODO: Come back with own API

const Cart = () => {
	const { CallApi: GetItemsInCart, data: itemsInCart } = useAuthFetch();
	useEffect(
		() => GetItemsInCart("carts/get", METHOD.GET),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	//console.log(itemsInCart ?? "");

	var itemsToDownload = [];
	if (itemsInCart) {
		for (let i = 0; i < itemsInCart?.products.length; i++) {
			itemsToDownload.push(itemsInCart.products[i].productId);
		}
	}

	const { CallApi: GetItemDetails, data: itemDetails } = useAuthFetch();

	const Output = () => {
		return (
			<div className="wholePage">
				{itemsToDownload.map((id, index) => {
					GetItemDetails("products", id, METHOD.GET);
					return (
						<img
							className="singleProductImage"
							key={index}
							src={itemDetails?.image}
							alt={itemDetails?.description}
						></img>
					);
				})}
			</div>
		);
	};

	return <Output />;
};

export default Cart;
