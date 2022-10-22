import React from "react";
import { Routes, Route } from "react-router-dom";
import useScrollToTop from "../utils/useScrollToTop";
import Contact from "../pages/Contact";
import Home from "../pages/Home";
import Products from "../pages/Products";
import Error from "../pages/Error";
import Category from "../pages/Category";
import SingleProductDetails from "../pages/SingleProductDetails";
import Cart from "../pages/Cart";

const PageChanger = () => {
	useScrollToTop();
	return (
		<Routes>
			<Route path="/" element={<Home />} />
			<Route path="/contact" element={<Contact />} />
			<Route path="/products" element={<Products />} />
			<Route path="/products/:category" element={<Category />} />
			<Route
				path="/products/details/:id"
				element={<SingleProductDetails />}
			/>
			<Route path={"/cart"} element={<Cart />} />
			<Route path="*" element={<Error />} />
		</Routes>
	);
};

export default PageChanger;
