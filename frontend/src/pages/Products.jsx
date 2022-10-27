import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD, apiEndpoints } from "../utils/useFetch";

const Products = () => {
	const { CallApi, data: products } = useFetch();
	// eslint-disable-next-line react-hooks/exhaustive-deps
	useEffect(() => CallApi(apiEndpoints("items/getallitems"), METHOD.GET), []);
	//useEffect(() => CallApi(apiEndpoints("products"), METHOD.GET), []);

	return (
		<>
			<div className="wholePage">
				{console.log(products)}
				{/* {products?.myBates.map((item) => {
					return <img src={`data:image/png;base64,${item}`} />;
					//return <SingleProduct product={item} />;
				})} */}
			</div>
		</>
	);
};

export default Products;
