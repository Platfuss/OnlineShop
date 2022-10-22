import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";
import SingleProduct from "../components/SingleProduct";

const Category = () => {
	let param = useParams();
	const { CallApi, data: products } = useFetch(
		apiEndpoints("products", "category", param.category),
		METHOD.GET
	);

	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => CallApi(), [param]);

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

export default Category;
