import React, { useEffect } from "react";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";
import useAddToCart from "../utils/useAddToCart";
import { useParams } from "react-router-dom";

const SingleProductDetails = () => {
	const params = useParams();
	const { CallApi: GetDetails, data: product } = useFetch(
		apiEndpoints("products", params.id),
		METHOD.GET
	);

	const date = new Date().toUTCString();
	const body = JSON.stringify({
		userId: 1,
		date: { date },
		products: [{ productId: product?.id, quantity: 1 }],
	});

	const { CallApi: AddToCart, isLoading: isAddingToCart } = useAddToCart(body);

	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => GetDetails(), []);

	const OnButtonClick = () => {
		AddToCart();
	};

	return (
		<div className="wholePage">
			<figure className="imageContainer">
				<img
					className="singleProductImage"
					src={`${product?.image}`}
					alt="productImage"
				></img>
			</figure>
			<div>{product?.category}</div>
			<div>{product?.title}</div>
			<div>{product?.price} zł</div>
			<button
				className="addToCartButton"
				onClick={OnButtonClick}
				disabled={isAddingToCart}
			>
				Dodaj do koszyka
			</button>
		</div>
	);
};
export default SingleProductDetails;
