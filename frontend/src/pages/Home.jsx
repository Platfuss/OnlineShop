import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD } from "../utils/useFetch";

const Home = () => {
	const { CallApi, data: products } = useFetch(
		"https://fakestoreapi.com/products",
		METHOD.GET
	);

	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => CallApi(), []);

	return (
		<>
			<div className="homePage wholePage">
				{products?.map((item) => {
					return <SingleProduct key={item.id} product={item} />;
				})}
			</div>
		</>
	);
};

export default Home;
