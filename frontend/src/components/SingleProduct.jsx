import React from "react";
import { NavLink } from "react-router-dom";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";

const SingleProduct = ({ product }) => {
	const route = `/products/details/${product.id}`;
	const date = new Date().toUTCString();
	const body = JSON.stringify({
		userId: 1,
		date: { date },
		products: [{ productId: product.id, quantity: 1 }],
	});

	const { CallApi, isLoading } = useFetch();

	const OnButtonClick = () => {
		CallApi(apiEndpoints("carts"), METHOD.POST, body);
	};

	return (
		<div className="singleProduct">
			<figure className="imageContainer">
				<NavLink end to={route}>
					<img
						className="singleProductImage"
						src={`${product.image}`}
						alt="productImage"
					></img>
				</NavLink>
			</figure>
			<div>{product.category}</div>
			<NavLink end to={route}>
				<div>{product.title}</div>
			</NavLink>
			<div>{product.price} zł</div>
			<div>Dostępny/Niedostępny</div>
			<button
				className="addToCartButton"
				onClick={OnButtonClick}
				disabled={isLoading}
			>
				Dodaj do koszyka
			</button>
		</div>
	);
};

export default SingleProduct;
