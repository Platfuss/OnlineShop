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
import Account from "./Account";
import CreateOrder from "./CreateOrder";

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
			<Route path="/create-order" element={<CreateOrder />} />
			<Route path="/account" element={<Account />} />
			<Route path="/login" element={<Login />} />
			<Route path="/cart" element={<Cart />} />
			<Route path="*" element={<Error />} />
		</Routes>
	);
};

export default PageChanger;
