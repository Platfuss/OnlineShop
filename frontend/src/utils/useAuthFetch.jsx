import useFetch from "./useFetch";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import useAuth from "./useAuth";

const useAuthFetch = () => {
	const [attempt, setAttempt] = useState(0);
	const [callData, setCallData] = useState({});
	const { CallApi: UnAuthCall, data, isLoading, error, status } = useFetch();
	const Navigate = useNavigate();
	const { setAuth } = useAuth();

	const CallApi = (url, method, body) => {
		setCallData({ url, method, body });
		UnAuthCall(url, method, body);
	};

	useEffect(() => {
		if (isLoading === false) {
			if (status === 401 && attempt === 0) {
				UnAuthCall("authentication/refresh-access-token", METHOD.POST);
				setAttempt(1);
				UnAuthCall(callData.url, callData.method, callData.body);
			} else if (status === 401 && attempt > 0) {
				setAuth(false);
				setAttempt(0);
				Navigate("/login-register");
			}
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isLoading]);

	return { CallApi, data, isLoading, error, status };
};

const METHOD = Object.freeze({
	GET: "GET",
	PUT: "PUT",
	POST: "POST",
	PATCH: "PATCH",
	DELETE: "DELETE",
});

export default useAuthFetch;
export { METHOD };
