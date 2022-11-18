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
	const { auth, setAuth } = useAuth();

	const { CallApi: Login, status: loginStatus } = useAuthFetch();
	const { CallApi: Register, status: registerStatus } = useAuthFetch();

	useEffect(() => {
		if (loginStatus === 200 || registerStatus === 200) {
			setAuth(true);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [loginStatus, registerStatus]);

	useEffect(() => {
		if (auth) {
			Navigate("/");
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [auth]);

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
		<div className="wholePage">
			<h1>Logowanie</h1>
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
				Zaloguj
			</button>

			<h1>Nie masz konta? Zarejestruj się!</h1>
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
						onChange={(e) => setRegisterPasswordConfirm(e.target.value)}
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
				Zarejestruj
			</button>
		</div>
	);
};

export default LoginRegister;
