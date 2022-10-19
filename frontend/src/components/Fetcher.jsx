import { useState, useEffect } from "react";

const Fetcher = (url, method, body) => {
  const [data, setData] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
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
        } else {
          console.log("Aborted fetch");
        }
      });

    return () => aborter.abort();
  }, [url]);

  return { data, isLoaded, error };
};

const METHODS = Object.freeze({
  GET: "GET",
  PUT: "PUT",
  POST: "POST",
  PATCH: "PATCH",
  DELETE: "DELETE",
});

export default Fetcher;
export { METHODS };
