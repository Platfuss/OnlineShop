import React, { useEffect } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import Img64Base from "../utils/Img64Base";

const Cart = () => {
	const { CallApi: GetItemsInCart, data: itemsInCart } = useAuthFetch();

	useEffect(
		() => GetItemsInCart("carts/get", METHOD.GET),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	return (
		<div className="wholePage">
			{itemsInCart?.map((item) => {
				return (
					<div key={item.itemId}>
						<Img64Base
							className="singleProductImage"
							src={item.image}
						></Img64Base>
						<h5>Hello</h5>
						<p>{item.name}</p>
						<p>{item.amount}</p>
						<p>{item.price}</p>
						<p>{item.price * item.amount}</p>
					</div>
				);
			})}
		</div>
	);
};

export default Cart;
