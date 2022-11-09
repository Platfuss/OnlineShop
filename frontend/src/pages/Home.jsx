import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";

const Home = () => {
	const testBody = JSON.stringify({
		email: "user@example.com",
		password: "string",
	});
	const { CallApi, data: products } = useFetch();
	// useEffect(
	// 	() => CallApi(apiEndpoints("items/getnewestitems"), METHOD.GET),
	// 	// eslint-disable-next-line react-hooks/exhaustive-deps
	// 	[]
	// );

	const { CallApi: abc } = useFetch();
	useEffect(
		() => abc(apiEndpoints("authentication/login"), METHOD.POST, testBody),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	return (
		<>
			<div className="wholePage">
				{/* <h1>Nowości!</h1>
				{products?.map((item) => (
					<SingleProduct key={item.id} product={item} />
				))} */}
			</div>
		</>
	);
};

export default Home;
