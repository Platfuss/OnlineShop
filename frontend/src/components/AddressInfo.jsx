import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const AddressInfo = ({ address, Callback }) => {
	const { CallApi: OnDelete, isLoading } = useAuthFetch();

	useEffect(() => {
		if (Callback && isLoading === false) {
			Callback();
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isLoading]);

	return (
		<div>
			{address.city}
			{address.street}
			{address.number}
			{address.subNumber ? `/${address.subNumber}` : ""}
			{address.postalCode}
			{Callback && (
				<button
					onClick={() => {
						OnDelete(`addresses/${address.id}`, METHOD.DELETE);
					}}
				>
					Usuń
				</button>
			)}
		</div>
	);
};

export default AddressInfo;
