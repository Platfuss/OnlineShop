import React from "react";
import NavBar from "./components/NavBar";
import { NavLink } from "react-router-dom";
import useAuth from "./utils/useAuth";
import useAuthFetch, { METHOD } from "./utils/useAuthFetch";
import { useNavigate } from "react-router-dom";

const Header = () => {
	const { auth, setAuth, cartTotal, setCartTotal } = useAuth();
	const { CallApi } = useAuthFetch();

	const Navigate = useNavigate();

	const OnLogOut = () => {
		CallApi("authentication/revoke-access", METHOD.DELETE);
		setAuth(false);
		setCartTotal(0);
		Navigate("/");
	};

	return (
		<header>
			<div className="header-up">
				<span>Darmowa dostawa od 300zł </span>
				<span>Szybka wysyłka i dobrze zabezpieczone zamówienie</span>
				<span>Sklep stacjonarny we Wrocławiu</span>
				{auth ? (
					<div className="loggedUser">
						<NavLink end to={"/account"}>
							Moje konto
						</NavLink>
						<button className="textualize" onClick={OnLogOut}>
							Wyloguj
						</button>
					</div>
				) : (
					<NavLink end to={"/login-register"}>
						Zaloguj/Zarejestruj
					</NavLink>
				)}
			</div>
			<div className="header-middle">
				<NavLink end to={"/"}>
					<h1 className="logo">Misz Masz</h1>
				</NavLink>
				<div className="goToCartButton">
					<NavLink end to={"/cart"}>
						<img src="cart.png" alt="" />
						<div>
							<p>Twój koszyk</p>
							<p>
								{new Intl.NumberFormat("pl-PL", {
									style: "currency",
									currency: "PLN",
								}).format(cartTotal)}
							</p>
						</div>
					</NavLink>
				</div>
			</div>

			<div className="header-bottom">
				<NavBar />
			</div>
		</header>
	);
};

export default Header;
