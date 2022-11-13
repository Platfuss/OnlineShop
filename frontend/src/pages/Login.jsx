import React from "react";
import useFetch, { METHOD } from "../utils/useFetch";
import { useEffect } from "react";

const Login = () => {
	const loginBody = JSON.stringify({
		email: "user@example.com",
		password: "string",
	});

	const { CallApi, data: expirationDates } = useFetch();

	const onLoginClick = () => {
		CallApi("authentication/login", METHOD.POST, loginBody);
	};

	useEffect(() => {
		if (expirationDates) {
			localStorage.setItem(
				"RefreshTokenExpirationDate",
				new Date(expirationDates.refreshTokenExpirationDate) + "Z"
			);
		}
	}, [expirationDates]);

	return (
		<div className="wholePage">
			<p>Login Page</p>
			<button onClick={() => onLoginClick()}>Zaloguj</button>
		</div>
	);
};

export default Login;
