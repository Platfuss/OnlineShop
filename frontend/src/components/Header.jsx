import React from "react";
import NavBar from "./NavBar";
import { NavLink } from "react-router-dom";
import useAuth from "../utils/useAuth";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const Header = () => {
	const { auth, setAuth } = useAuth();
	const { CallApi } = useAuthFetch();

	const OnLogOut = () => {
		CallApi("authentication/revoke-access", METHOD.DELETE);
		setAuth(false);
		localStorage.removeItem("RefreshTokenExpirationDate");
	};

	return (
		<header>
			<div>
				{auth ? (
					<div>
						<NavLink end to={"/account"}>
							Moje konto
						</NavLink>
						<button onClick={OnLogOut}>Wyloguj</button>
					</div>
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
