import React from "react";
import { NavLink } from "react-router-dom";
import Img64Base from "../utils/Img64Base";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const SingleProduct = ({ product }) => {
	var isAvailable = product.amount;
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
			<div className="productInfo">
				<span>{product.category}</span>
				<NavLink end to={route}>
					<b>
						<span>{product.name}</span>
					</b>
				</NavLink>
				<span>{product.price} zł</span>
				<div>
					<div className={`dot ${isAvailable ? "available" : ""}`}></div>
					{isAvailable ? "Dostępny" : "Niedostępny"}{" "}
				</div>
				<div className="hiddenButtonContainer">
					<button
						onClick={OnButtonClick}
						disabled={product.amount < 1 || isLoading}
					>
						Dodaj do koszyka
					</button>
				</div>
			</div>
		</div>
	);
};

export default SingleProduct;
