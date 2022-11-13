import useFetch, { METHOD, apiEndpoints } from "./useFetch";
import { useEffect } from "react";

const LoginKeeper = () => {
	const { CallApi, data: expirationDates } = useFetch();

	useEffect(() => {
		if (refreshTokenExpire) {
			const now = new Date();
			const refreshExpire = new Date(
				localStorage.getItem("RefreshTokenExpirationDate")
			);
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
