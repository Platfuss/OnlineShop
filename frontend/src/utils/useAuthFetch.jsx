import useFetch, { METHOD } from "./useFetch";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const useAuthFetch = () => {
	const [attempt, setAttempt] = useState(0);
	const [callData, setCallData] = useState({});
	const { CallApi: UnAuthCall, data, isLoading, error, status } = useFetch();
	const navigate = useNavigate();

	const CallApi = (url, method, body) => {
		setCallData({ url, method, body });
		UnAuthCall(url, method, body);
	};

	useEffect(() => {
		if (isLoading === false) {
			console.log(status, attempt);
			if (status === 401 && attempt === 0) {
				UnAuthCall("authentication/refresh-access-token", METHOD.POST);
				setAttempt(1);
				UnAuthCall(callData.url, callData.method, callData.body);
			} else if (status === 401 && attempt > 0) {
				setAttempt(0);
				navigate("/login");
			}
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isLoading]);

	return { CallApi, data, isLoading, error, status };
};

export default useAuthFetch;
