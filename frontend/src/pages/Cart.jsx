import React, { useEffect } from "react";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";

const fakeUserId = 5;

//TODO: Come back with own API

const Cart = () => {
	const { CallApi: GetItemsInCart, data: itemsInCart } = useFetch();
	useEffect(
		() => GetItemsInCart(apiEndpoints("carts/get", fakeUserId), METHOD.GET),
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

	const { CallApi: GetItemDetails, data: itemDetails } = useFetch();

	const Output = () => {
		return (
			<div className="wholePage">
				{itemsToDownload.map((id, index) => {
					GetItemDetails(apiEndpoints("products", id), METHOD.GET);
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
