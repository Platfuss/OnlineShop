import React from "react";
import { useParams } from "react-router-dom";

const Category = () => {
	let param = useParams();
	return <h1>{param.category}</h1>;
};

export default Category;
