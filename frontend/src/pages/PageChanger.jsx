import React from "react";
import { Routes, Route } from "react-router-dom";
import useScrollToTop from "../utils/useScrollToTop";
import Contact from "./Contact";
import Home from "./Home";
import Products from "./Products";
import Error from "./Error";
import Category from "./Category";
import SingleProductDetails from "./SingleProductDetails";
import Cart from "./Cart";
import Login from "./Login";

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
			<Route path="/login" element={<Login />} />
			<Route path="/cart" element={<Cart />} />
			<Route path="*" element={<Error />} />
		</Routes>
	);
};

export default PageChanger;
