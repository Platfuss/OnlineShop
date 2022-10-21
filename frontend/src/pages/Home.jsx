import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD } from "../utils/useFetch";

const Home = () => {
	const {
		CallApi,
		data: products,
		isLoaded,
	} = useFetch("https://fakestoreapi.com/products", METHOD.GET);

	useEffect(() => CallApi(), []);

	return (
		<>
			<div className="homePage wholePage">
				{isLoaded &&
					products.map((item) => {
						return <SingleProduct key={item.id} product={item} />;
					})}
			</div>
		</>
	);
};

export default Home;
