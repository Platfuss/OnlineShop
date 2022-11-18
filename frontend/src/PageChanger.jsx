import React from "react";
import { Routes, Route } from "react-router-dom";
import useScrollToTop from "./utils/useScrollToTop";
import Contact from "./pages/Contact";
import Home from "./pages/Home";
import Products from "./pages/Products";
import Error from "./pages/Error";
import Category from "./pages/Category";
import SingleProductDetails from "./pages/SingleProductDetails";
import Cart from "./pages/Cart";
import Account from "./pages/Account";
import CreateOrder from "./pages/CreateOrder";
import OrderConfirm from "./pages/OrderConfirm";
import AddressEditor from "./pages/AddressEditor";
import LoginRegister from "./pages/LoginRegister";
import ProfilEditor from "./pages/ProfilEditor";

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
			<Route path="/profil" element={<ProfilEditor />} />
			<Route path="/create-order" element={<CreateOrder />} />
			<Route path="/order-confirm" element={<OrderConfirm />} />
			<Route path="/address/:id" element={<AddressEditor />} />
			<Route path="/address/new" element={<AddressEditor />} />
			<Route path="/account" element={<Account />} />
			<Route path="/login-register" element={<LoginRegister />} />
			<Route path="/cart" element={<Cart />} />
			<Route path="*" element={<Error />} />
		</Routes>
	);
};

export default PageChanger;
