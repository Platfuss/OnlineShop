import React from "react";
import NavBar from "./NavBar";
import { NavLink } from "react-router-dom";
import useAuth from "../utils/useAuth";

const Header = () => {
	const { auth } = useAuth();

	return (
		<header>
			<div>
				{auth ? (
					"Moje konto - Wyloguj"
				) : (
					<NavLink end to={"/login"}>
						Zaloguj/Zarejestruj
					</NavLink>
				)}
			</div>
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
