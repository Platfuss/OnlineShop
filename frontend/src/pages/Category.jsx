import React from "react";
import { useParams } from "react-router-dom";

const Category = () => {
	let param = useParams();
	return (
		<div className="wholePage">
			<h1>{param.category}</h1>
		</div>
	);
};

export default Category;
