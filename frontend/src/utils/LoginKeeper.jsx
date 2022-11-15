import useFetch, { METHOD } from "./useFetch";
import { useEffect } from "react";

const LoginKeeper = () => {
	const { CallApi, data: expirationDates } = useFetch();
	const refreshTokenExpire = localStorage.getItem(
		"RefreshTokenExpirationDate"
	);

	useEffect(() => {
		if (refreshTokenExpire) {
			const now = new Date();
			const refreshExpireDate = new Date(refreshTokenExpire);
			console.log(now, refreshExpireDate);
			if (now < refreshExpireDate) {
				CallApi("authentication/refresh-access-token", METHOD.POST);
			}
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (expirationDates) {
			localStorage.setItem(
				"RefreshTokenExpirationDate",
				new Date(expirationDates.refreshTokenExpirationDate) + "Z"
			);
		}
	}, [expirationDates]);

	return <></>;
};

export default LoginKeeper;
