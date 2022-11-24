import React from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import { useEffect, useState } from "react";
import useAuth from "../utils/useAuth";
import { useNavigate } from "react-router-dom";

const emailPattern = new RegExp(/^\w+@(\w+\.)+\w+$/);

const LoginRegister = () => {
	const [loginEmail, setLoginEmail] = useState("user@example.com");
	const [loginPassword, setLoginPassword] = useState("string");

	const [registerEmail, setRegisterEmail] = useState("");
	const [registerPassword, setRegisterPassword] = useState("");
	const [registerPasswordConfirm, setRegisterPasswordConfirm] = useState("");

	const Navigate = useNavigate();
	const { auth, setAuth, setCartTotal } = useAuth();

	const { CallApi: Login, status: loginStatus } = useAuthFetch();
	const { CallApi: Register, status: registerStatus } = useAuthFetch();
	const { CallApi: GetCartTotalPrice, data: cartTotalPrice } = useAuthFetch();

	useEffect(() => {
		if (loginStatus === 200 || registerStatus === 200) {
			setAuth(true);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [loginStatus, registerStatus]);

	useEffect(() => {
		if (auth) {
			GetCartTotalPrice("carts/total-price", METHOD.GET);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [auth]);

	useEffect(() => {
		if (cartTotalPrice === 0 || cartTotalPrice) {
			setCartTotal(cartTotalPrice);
			Navigate(-1, { replace: true });
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [cartTotalPrice]);

	const OnLoginClick = () => {
		Login(
			"authentication/login",
			METHOD.POST,
			JSON.stringify({ email: loginEmail, password: loginPassword })
		);
	};

	const OnRegisterClick = () => {
		Register(
			"authentication/register",
			METHOD.POST,
			JSON.stringify({ email: registerEmail, password: registerPassword })
		);
	};

	return (
		<div className="loginPage">
			<div className="formContainer">
				<h1>Zaloguj się</h1>
				<form>
					<label>
						Email
						<input
							value={loginEmail}
							onChange={(e) => setLoginEmail(e.target.value)}
						/>
					</label>
					<label>
						Hasło
						<input
							type={"password"}
							value={loginPassword}
							onChange={(e) => setLoginPassword(e.target.value)}
						/>
					</label>
				</form>
				<button
					onClick={() => OnLoginClick()}
					disabled={!(loginEmail && loginPassword)}
				>
					Zaloguj się
				</button>
			</div>

			<div className="formContainer">
				<h1>Nie masz konta?</h1>
				<h1> Zarejestruj się!</h1>
				<form>
					<label>
						Email
						<input
							value={registerEmail}
							onChange={(e) => setRegisterEmail(e.target.value)}
						/>
					</label>
					<label>
						Hasło
						<input
							type={"password"}
							value={registerPassword}
							onChange={(e) => setRegisterPassword(e.target.value)}
						/>
					</label>
					<label>
						Potwierdź hasło
						<input
							type={"password"}
							value={registerPasswordConfirm}
							onChange={(e) =>
								setRegisterPasswordConfirm(e.target.value)
							}
						/>
					</label>
				</form>

				<button
					onClick={() => OnRegisterClick()}
					disabled={
						!(
							emailPattern.test(registerEmail) &&
							registerPassword.length >= 3 &&
							registerPassword === registerPasswordConfirm
						)
					}
				>
					Załóż konto
				</button>
			</div>
		</div>
	);
};

export default LoginRegister;
