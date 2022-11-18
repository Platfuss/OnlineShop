import React, { useEffect } from "react";
import useFetch, { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import { useNavigate, useParams } from "react-router-dom";
import Img64Base from "../utils/Img64Base";

const SingleProductDetails = () => {
	const Navigate = useNavigate();
	const params = useParams();
	const { CallApi: GetDetails, data: product } = useFetch();
	const { CallApi: AddToCart, isLoading: isAddingToCart } = useAuthFetch();

	useEffect(
		() => GetDetails(`items/${params.id}`, METHOD.GET),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	const cartInfo = JSON.stringify({ itemId: params.Id, amount: 1 });

	const OnButtonClick = () => {
		AddToCart("carts", METHOD.POST, cartInfo);
	};

	return (
		<div className="wholePage">
			{product && (
				<>
					<figure className="imageContainer">
						{product.images.map((img, index) => {
							return (
								<Img64Base
									key={index}
									className="singleProductImage"
									src={img}
								></Img64Base>
							);
						})}
					</figure>
					<div>{product.category}</div>
					<div>{product.name}</div>
					<div>{product.price} zł</div>
					<button
						className="addToCartButton"
						onClick={OnButtonClick}
						disabled={isAddingToCart}
					>
						Dodaj do koszyka
					</button>
					<div>{product.decription}</div>
					<button onClick={() => Navigate(-1)}>Powrót</button>
				</>
			)}
		</div>
	);
};
export default SingleProductDetails;
