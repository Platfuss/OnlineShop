import React from "react";
import { NavLink } from "react-router-dom";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";
import Img64Base from "../utils/Img64Base";

const SingleProduct = ({ product }) => {
	const route = `/products/details/${product.id}`;
	const date = new Date().toUTCString();
	const body = JSON.stringify({
		userId: 0,
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
					{product.images && (
						<Img64Base
							className="singleProductImage"
							src={product.images[0]}
						></Img64Base>
					)}
				</NavLink>
			</figure>
			<div>{product.category}</div>
			<NavLink end to={route}>
				<div>{product.name}</div>
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
