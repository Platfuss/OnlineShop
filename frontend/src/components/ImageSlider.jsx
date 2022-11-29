import React, { useEffect, useRef } from "react";
import Img64Base from "../utils/Img64Base";

const ImageSlider = ({ images }) => {
	const visibleImageId = useRef(0);
	const imagePool = useRef([]);
	const slidingButtons = useRef([]);
	const timeoutsIds = useRef([]);

	const imgsLen = images.length ?? 0;
	const imgCount = imgsLen === 2 ? 4 : imgsLen;

	useEffect(() => {
		const toClear = timeoutsIds.current;
		return () => {
			toClear.forEach((ti) => {
				clearTimeout(ti);
			});
		};
	}, []);

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
		} else if (imagePool.current.length === 1) {
			imagePool.current[visibleImageId.current].classList.add(
				"choosen",
				"visible"
			);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [images]);

	const DisableButtons = () => {
		slidingButtons.current[0].disabled = true;
		slidingButtons.current[1].disabled = true;
		timeoutsIds.current.push(
			setTimeout(() => {
				slidingButtons.current[0].disabled = false;
				slidingButtons.current[1].disabled = false;
			}, 550)
		);
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
		const imgs = images.map((img, idx) => {
			return (
				<Img64Base
					src={img}
					key={idx}
					innerRef={(el) => (imagePool.current[idx] = el)}
				/>
			);
		});

		if (images.length === 2) {
			images.map((img, idx) => {
				return imgs.push(
					<Img64Base
						src={img}
						key={idx + 2}
						innerRef={(el) => (imagePool.current[idx + 2] = el)}
					/>
				);
			});
		}

		return <>{imgs}</>;
	};

	return (
		<figure className="imageSlider">
			{images.length && <ImageSpawner />}
			<ImageSpawner />
			{images.length > 1 ? (
				<>
					<button
						className="prev"
						onClick={() => OnGoPrevious()}
						ref={(el) => (slidingButtons.current[0] = el)}
					>
						{"<"}
					</button>
					<button
						className="next"
						onClick={() => OnGoNext()}
						ref={(el) => (slidingButtons.current[1] = el)}
					>
						{">"}
					</button>
				</>
			) : (
				<></>
			)}
		</figure>
	);
};

export default ImageSlider;
