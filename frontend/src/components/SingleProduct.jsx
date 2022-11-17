import React from "react";
import { NavLink } from "react-router-dom";
import Img64Base from "../utils/Img64Base";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const SingleProduct = ({ product }) => {
	const route = `/products/details/${product.id}`;
	const body = JSON.stringify({
		itemId: product.id,
		amount: 1,
	});

	const { CallApi, isLoading } = useAuthFetch();

	const OnButtonClick = () => {
		CallApi("carts/add-item", METHOD.POST, body);
	};

	return (
		<div className="singleProduct">
			<figure className="imageContainer">
				<NavLink end to={route}>
					<Img64Base
						className="singleProductImage"
						src={product.image}
					></Img64Base>
				</NavLink>
			</figure>
			<div>{product.category}</div>
			<NavLink end to={route}>
				<div>{product.name}</div>
			</NavLink>
			<div>{product.price} zł</div>
			<div>{product.amount > 0 ? "Dostępny" : "Niedostępny"}</div>
			<button
				className="addToCartButton"
				onClick={OnButtonClick}
				disabled={product.amount < 1 || isLoading}
			>
				Dodaj do koszyka
			</button>
		</div>
	);
};

export default SingleProduct;
