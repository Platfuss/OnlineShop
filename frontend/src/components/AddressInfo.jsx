import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import { useNavigate } from "react-router-dom";

const AddressInfo = ({ address, RefreshOnDelete }) => {
	const navigate = useNavigate();
	const { CallApi: OnDelete, isLoading } = useAuthFetch();

	useEffect(() => {
		if (RefreshOnDelete && isLoading === false) {
			RefreshOnDelete();
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
			{RefreshOnDelete && (
				<button onClick={() => navigate(`/address/${address.id}`)}>
					Edytuj
				</button>
			)}
			{RefreshOnDelete && (
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
