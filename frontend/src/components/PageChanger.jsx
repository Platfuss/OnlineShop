import React from "react";
import { Routes, Route } from "react-router-dom";
import Contact from "../pages/Contact";
import Home from "../pages/Home";
import Products from "../pages/Products";
import Error from "../pages/Error";
import Category from "../pages/Category";

const PageChanger = () => {
	return (
		<Routes>
			<Route path="/" element={<Home />} />
			<Route path="/contact" element={<Contact />} />
			<Route path="/products" element={<Products />} />
			<Route path="/products/:category" element={<Category />} />
			<Route path="*" element={<Error />} />
		</Routes>
	);
};

export default PageChanger;
