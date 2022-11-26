import React, { useEffect, useRef } from "react";
import useFetch, { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import { useNavigate, useParams } from "react-router-dom";
import Img64Base from "../utils/Img64Base";
import { useState } from "react";

const SingleProductDetails = () => {
	const Navigate = useNavigate();
	const params = useParams();
	const visibleImageId = useRef(0);
	const imagePool = useRef([]);
	const slidingButtons = useRef([]);
	const timeoutsIds = useRef([]);
	const { CallApi: GetDetails, data: product } = useFetch();
	const { CallApi: AddToCart, isLoading: isAddingToCart } = useAuthFetch();

	const imgsLen = product?.images?.length ?? 0;
	const imgCount = imgsLen === 2 ? 4 : imgsLen;

	useEffect(
		() => {
			GetDetails(`items/${params.id}`, METHOD.GET);
			return () => {
				timeoutsIds.current.forEach((ti) => {
					console.log(ti);
					clearTimeout(ti);
				});
			};
		},
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	useEffect(() => {
		if (imagePool.current.length > 1) {
			const nextId = GetNextImageId();
			const prevId = GetPreviousImageId();
			imagePool.current[prevId].classList.add("previous");
			imagePool.current[visibleImageId.current].classList.add(
				"choosen",
				"visible"
			);
			imagePool.current[nextId].classList.add("next");
		}
	}, [product]);

	const cartInfo = JSON.stringify({ itemId: params.Id, amount: 1 });

	const OnButtonClick = () => {
		AddToCart("carts", METHOD.POST, cartInfo);
	};

	const DisableButtons = () => {
		slidingButtons.current[0].disabled = true;
		slidingButtons.current[1].disabled = true;
		timeoutsIds.current.push(
			setTimeout(() => {
				slidingButtons.current[0].disabled = false;
				slidingButtons.current[1].disabled = false;
			}, 550)
		);
		console.log(timeoutsIds.current);
	};

	const OnGoPrevious = () => {
		DisableButtons();
		const previousId = GetPreviousImageId();
		imagePool.current[previousId].classList.remove("previous", "visible");

		imagePool.current[visibleImageId.current].classList.replace(
			"choosen",
			"previous"
		);
		visibleImageId.current = GetNextImageId();

		imagePool.current[visibleImageId.current].classList.replace(
			"next",
			"choosen"
		);
		imagePool.current[visibleImageId.current].classList.add("visible");

		const nextId = GetNextImageId();
		imagePool.current[nextId].classList.add("next");
	};

	const OnGoNext = () => {
		DisableButtons();
		const nextId = GetNextImageId();
		imagePool.current[nextId].classList.remove("next", "visible");

		imagePool.current[visibleImageId.current].classList.replace(
			"choosen",
			"next"
		);
		visibleImageId.current = GetPreviousImageId();

		imagePool.current[visibleImageId.current].classList.replace(
			"previous",
			"choosen"
		);
		imagePool.current[visibleImageId.current].classList.add("visible");

		const previousId = GetPreviousImageId();
		imagePool.current[previousId].classList.add("previous");
	};

	const GetNextImageId = () => {
		if (visibleImageId.current + 1 >= imgCount) {
			return 0;
		}
		return visibleImageId.current + 1;
	};

	const GetPreviousImageId = () => {
		if (visibleImageId.current - 1 < 0) {
			return imgCount - 1;
		}
		return visibleImageId.current - 1;
	};

	const ImageSpawner = () => {
		const images = product.images.map((img, idx) => {
			return (
				<Img64Base
					src={img}
					key={idx}
					innerRef={(el) => (imagePool.current[idx] = el)}
				/>
			);
		});

		if (product.images.length == 2) {
			product.images.map((img, idx) => {
				images.push(
					<Img64Base
						src={img}
						key={idx + 2}
						innerRef={(el) => (imagePool.current[idx + 2] = el)}
					/>
				);
			});
		}

		return <>{images}</>;
	};

	return (
		<div className="singleProductPage">
			{product && (
				<>
					<figure className="imageSlider">
						<ImageSpawner />
						{product.images.length > 1 ? (
							<>
								<button
									className="prev"
									onClick={() => OnGoPrevious()}
									ref={(el) =>
										(slidingButtons.current[0] = el)
									}
								>
									{"<"}
								</button>
								<button
									className="next"
									onClick={() => OnGoNext()}
									ref={(el) =>
										(slidingButtons.current[1] = el)
									}
								>
									{">"}
								</button>
							</>
						) : (
							<></>
						)}
					</figure>
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
