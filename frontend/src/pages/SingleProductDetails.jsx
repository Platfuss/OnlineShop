import React, { useEffect, useState } from "react";
import useFetch, { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import { useNavigate, useParams } from "react-router-dom";
import ImageSlider from "../components/ImageSlider";
import { useMemo } from "react";
import useAuth from "../utils/useAuth";

const SingleProductDetails = () => {
	const Navigate = useNavigate();
	const params = useParams();
	const { setCartTotal } = useAuth();
	const { CallApi: GetDetails, data: product } = useFetch();
	const { CallApi: AddToCart, isLoading: isAddingToCart } = useAuthFetch();
	const { CallApi: GetCartTotalPrice, data: cartTotalPrice } = useAuthFetch();
	const [wasButtonClicked, setWasButtonClicked] = useState(false);
	const MemorizedSlider = useMemo(
		() => <ImageSlider images={product?.images} />,
		[product]
	);

	useEffect(() => {
		GetDetails(`items/${params.id}`, METHOD.GET);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	const body = JSON.stringify({ itemId: params.id, amount: 1 });
	const OnButtonClick = () => {
		AddToCart("carts/add-item", METHOD.POST, body);
		setWasButtonClicked(true);
	};

	useEffect(() => {
		if (wasButtonClicked && isAddingToCart === false) {
			GetCartTotalPrice("carts/total-price", METHOD.GET);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isAddingToCart]);

	useEffect(() => {
		if (cartTotalPrice === 0 || cartTotalPrice) {
			setCartTotal(cartTotalPrice);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [cartTotalPrice]);

	return (
		<div className="singleProductPage">
			{product && (
				<>
					{MemorizedSlider}
					<div className="productOverview">
						<h3>{product.category}</h3>
						<h1>{product.name}</h1>
						<div>Cena: {product.price} zł</div>
						<button
							className="addToCartButton"
							onClick={OnButtonClick}
							disabled={isAddingToCart}
						>
							Dodaj do koszyka
						</button>
					</div>
					<div className="breakLine"></div>
					<h3>Opis produktu</h3>
					<textarea disabled value={product.description} />
					<div className="breakLine"></div>
					<button onClick={() => Navigate(-1)}>Powrót</button>
				</>
			)}
		</div>
	);
};
export default SingleProductDetails;
