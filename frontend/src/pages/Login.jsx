import React from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import { useEffect } from "react";
import useAuth from "../utils/useAuth";

const Login = () => {
	const loginBody = JSON.stringify({
		email: "user@example.com",
		password: "string",
	});
	const { setAuth } = useAuth();

	const { CallApi, data: expirationDates, status } = useAuthFetch();

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

		if (status === 200) {
			setAuth(true);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [expirationDates, status]);

	return (
		<div className="wholePage">
			<p>Login Page</p>
			<button onClick={() => onLoginClick()}>Zaloguj</button>
		</div>
	);
};

export default Login;
