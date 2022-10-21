import { useState } from "react";

const useFetch = (url, method, body) => {
	const [data, setData] = useState(null);
	const [isLoaded, setIsLoaded] = useState(false);
	const [error, setError] = useState(null);

	const CallApi = () => {
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
				setIsLoaded(true);
				setError(null);
			})
			.catch((e) => {
				if (e.name !== "AbortError") {
					setIsLoaded(false);
					setError(e.message);
					console.log("Unknown error from fetcher: " + e.message);
				}
			});

		return () => aborter.abort();
	};

	return { CallApi, data, isLoaded, error };
};

const METHOD = Object.freeze({
	GET: "GET",
	PUT: "PUT",
	POST: "POST",
	PATCH: "PATCH",
	DELETE: "DELETE",
});

export default useFetch;
export { METHOD };
