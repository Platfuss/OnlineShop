import React from "react";
import SingleProduct from "../components/SingleProduct";
import Fetcher, { METHOD } from "../utils/Fetcher";

const Home = () => {
	const { data: products, isLoaded } = Fetcher(
		"https://fakestoreapi.com/products",
		METHOD.GET
	);

	return (
		<>
			<div className="homePage">
				{isLoaded &&
					products.map((item) => {
						return <SingleProduct product={item} />;
					})}
			</div>
		</>
	);
};

export default Home;
