import useFetch, { METHOD, apiEndpoints } from "./useFetch";
import { useEffect, useState } from "react";

const LoginKeeper = () => {
	const [refreshTokenExpire, setRefreshTokenExpire] = useState(
		localStorage.getItem("RefreshTokenExpirationDate")
	);

	const { CallApi, data: expirationDates } = useFetch();

	useEffect(() => {
		if (refreshTokenExpire) {
			const now = new Date().toUTCString();
			const refreshExpire = new Date(refreshTokenExpire);
			console.log(now, refreshExpire);
			if (now < refreshExpire) {
				CallApi(
					apiEndpoints("authentication/refresh-access-token"),
					METHOD.POST
				);
			}
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		const interval = setInterval(() => {
			const rted = new Date(
				localStorage.getItem("RefreshTokenExpirationDate")
			).toUTCString();

			if (new Date().toUTCString() < rted) {
				CallApi(
					apiEndpoints("authentication/refresh-access-token"),
					METHOD.POST
				);
			}
			console.log({
				Teraz: new Date().toUTCString(),
				TokenKoniec: rted,
			});
		}, 1000 * 60 * 10);

		return () => clearInterval(interval);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (expirationDates) {
			localStorage.setItem(
				"RefreshTokenExpirationDate",
				new Date(expirationDates.refreshTokenExpirationDate) + "Z"
			);
			setRefreshTokenExpire(
				new Date(expirationDates.refreshTokenExpirationDate) + "Z"
			);
		}
	}, [expirationDates]);

	return <></>;
};

export default LoginKeeper;
