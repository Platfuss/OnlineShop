import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import useAuthFetch from "../utils/useAuthFetch";
import { METHOD } from "../utils/useFetch";
import { useNavigate } from "react-router-dom";

const postalCodePattern = new RegExp(/^\d{2}-\d{3}$/);

const AddressEditor = () => {
	const Navigate = useNavigate();
	const param = useParams();
	const paramHasId = Object.keys(param).length > 0;
	const { CallApi: GetAddress, data: address } = useAuthFetch();
	const { CallApi: SubmitAddress, status: addressSubmitStatus } =
		useAuthFetch();

	const [city, setCity] = useState("");
	const [street, setStreet] = useState("");
	const [number, setNumber] = useState("");
	const [subNumber, setSubNumber] = useState("");
	const [postalCode, setPostalCode] = useState("");

	var addressBody = {};
	if (paramHasId) {
		addressBody["id"] = param.id;
	}
	addressBody = JSON.stringify({
		...addressBody,
		city: city,
		street: street,
		number: number,
		subNumber: subNumber,
		postalCode: postalCode,
	});

	useEffect(() => {
		if (paramHasId) {
			GetAddress(`addresses/${param.id}`);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [param]);

	useEffect(() => {
		if (address) {
			setCity(address.city);
			setStreet(address.street);
			setNumber(address.number);
			setSubNumber(address.subNumber);
			setPostalCode(address.postalCode);
		}
	}, [address]);

	const Submit = () => {
		if (paramHasId) {
			SubmitAddress("addresses/update", METHOD.PATCH, addressBody);
		} else {
			SubmitAddress("addresses/add", METHOD.POST, addressBody);
		}
	};

	useEffect(() => {
		if (addressSubmitStatus === 200) {
			Navigate("/account");
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [addressSubmitStatus]);

	return (
		<div className="wholePage">
			<form>
				<label>
					Miasto
					<input
						value={city}
						onChange={(e) => {
							setCity(e.target.value);
						}}
					/>
				</label>{" "}
				<label>
					Ulica
					<input
						value={street}
						onChange={(e) => {
							setStreet(e.target.value);
						}}
					/>
				</label>{" "}
				<label>
					Numer domu
					<input
						value={number}
						onChange={(e) => {
							setNumber(e.target.value);
						}}
					/>
				</label>{" "}
				<label>
					Numer lokalu
					<input
						value={subNumber}
						onChange={(e) => {
							setSubNumber(e.target.value);
						}}
					/>
				</label>{" "}
				<label>
					Kod pocztowy
					<input
						value={postalCode}
						onChange={(e) => {
							setPostalCode(e.target.value);
						}}
						placeholder={"00-000"}
					/>
				</label>
			</form>
			<button
				onClick={Submit}
				disabled={
					!(city && street && number && postalCodePattern.test(postalCode))
				}
			>
				{paramHasId ? "Aktualizuj" : "Utwórz"}
			</button>
		</div>
	);
};

export default AddressEditor;
