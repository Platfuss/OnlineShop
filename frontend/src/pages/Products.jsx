import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";

const Products = () => {
	const { CallApi, data: products } = useFetch();

	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => CallApi(apiEndpoints("products"), METHOD.GET), []);

	return (
		<>
			<div className="wholePage">
				{products?.map((item) => {
					return <SingleProduct key={item.id} product={item} />;
				})}
			</div>
		</>
	);
};

export default Products;
