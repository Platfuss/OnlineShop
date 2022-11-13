import { useState } from "react";
//import { useNavigate } from "react-router-dom";

const useFetch = () => {
	const [data, setData] = useState(null);
	const [isLoading, setIsLoading] = useState(false);
	const [error, setError] = useState(null);
	const [status, setStatus] = useState(null);
	//const navigate = useNavigate();

	const CallApi = (url, method, body) => {
		console.log(url);
		setIsLoading(true);
		const aborter = new AbortController();
		fetch(apiEndpoints(url), {
			headers: {
				"Content-Type": "application/json",
			},
			//TODO: credentials
			credentials: "include",
			method: method,
			body: body,
			signal: aborter.signal,
		})
			.then((result) => {
				// if (result.status === 401) {
				// 	navigate("/login");
				// 	throw Error("User not logged in");
				// }
				setStatus(result.status);
				if (!result) {
					throw Error("Couldn't get data from server");
				}
				return result?.json();
			})
			.then((result) => {
				setData(result);
				setError(null);
			})
			.catch((e) => {
				if (e.name !== "AbortError") {
					setError(e);
					console.log("Fetcher error: " + e.message);
				}
			})
			.finally(() => setIsLoading(false));

		return () => aborter.abort();
	};

	return { CallApi, data, isLoading, error, status };
};

const beginning = "https://localhost:7177/api";

const apiEndpoints = (url) => {
	let address = beginning;
	address += "/" + url;
	return address;
};

const METHOD = Object.freeze({
	GET: "GET",
	PUT: "PUT",
	POST: "POST",
	PATCH: "PATCH",
	DELETE: "DELETE",
});

export default useFetch;
export { METHOD, apiEndpoints };
