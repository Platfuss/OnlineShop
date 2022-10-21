import React from "react";

const SingleProduct = ({ product }) => {
	return (
		<div className="singleProduct">
			<figure className="imageContainer">
				<img
					className="singleProductImage"
					src={`${product.image}`}
					alt="productImage"
				></img>
			</figure>
			<div>{product.title}</div>
			<div> {product.price} zł</div>
			<button className="addToCart">Dodaj do koszyka</button>
		</div>
	);
};

export default SingleProduct;
