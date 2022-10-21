import React from "react";
import useFetch, { METHOD } from "../utils/useFetch";

const SingleProduct = ({ product }) => {
	const date = new Date().toUTCString();
	const body = JSON.stringify({
		userId: 1,
		date: { date },
		products: [{ productId: product.id, quantity: 1 }],
	});

	const {
		CallApi,
		data: addedItemId,
		isLoaded,
	} = useFetch("https://fakestoreapi.com/carts", METHOD.POST, body);

	const OnButtonClick = () => {
		CallApi();
	};

	return (
		<div className="singleProduct">
			<figure className="imageContainer">
				<img
					className="singleProductImage"
					src={`${product.image}`}
					alt="productImage"
				></img>
			</figure>
			<div>{product.category}</div>
			<div>{product.title}</div>
			<div>{product.price} zł</div>
			<button className="addToCartButton" onClick={OnButtonClick}>
				Dodaj do koszyka
			</button>
			{/* {isLoaded && console.log(cartConfirm)} */}
		</div>
	);
};

export default SingleProduct;
