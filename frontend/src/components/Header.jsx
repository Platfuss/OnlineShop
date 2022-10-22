import React from "react";
import NavBar from "./NavBar";
import { NavLink } from "react-router-dom";

const Header = () => {
	return (
		<header>
			<div>Szybki dostęp</div>
			<div>
				<NavLink end to={"/"}>
					<h1 className="logo">Misz Masz</h1>
				</NavLink>
				<NavLink end to={"/cart"}>
					<button>Koszyk</button>
				</NavLink>
			</div>

			<NavBar />
		</header>
	);
};

export default Header;
