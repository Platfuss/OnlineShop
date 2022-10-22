import useFetch, { METHOD, apiEndpoints } from "./useFetch";

const useAddToCart = (body) => {
	const { CallApi, data, isLoading, error } = useFetch(
		apiEndpoints("carts"),
		METHOD.POST,
		body
	);

	return { CallApi, data, isLoading, error };
};

export default useAddToCart;
