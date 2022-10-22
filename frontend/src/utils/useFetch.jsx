import { useState } from "react";

const useFetch = (url, method, body) => {
	const [data, setData] = useState(null);
	const [isLoading, setIsLoading] = useState(false);
	const [error, setError] = useState(null);

	const CallApi = () => {
		setIsLoading(true);
		const aborter = new AbortController();
		fetch(url, {
			method: method,
			body: body,
			signal: aborter.signal,
		})
			.then((result) => {
				if (!result) {
					throw Error("Couldn't get data from server");
				}
				return result.json();
			})
			.then((result) => {
				setData(result);
				setError(null);
			})
			.catch((e) => {
				if (e.name !== "AbortError") {
					setError(e.message);
					console.log("Unknown error from fetcher: " + e.message);
				}
			})
			.finally(() => setIsLoading(false));

		return () => aborter.abort();
	};

	return { CallApi, data, isLoading, error };
};

const beginning = "https://fakestoreapi.com";

const apiEndpoints = (...props) => {
	let address = beginning;
	for (const property in props) {
		address += "/" + props[property];
	}
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
