import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const CreateOrder = () => {
	const { CallApi: GetProfil, data: profil } = useAuthFetch();
	const { CallApi: GetAddresses, data: addresses } = useAuthFetch();
	const [shippingIdx, setShippingIdx] = useState(null);
	const [invoiceIdx, setInvoiceIdx] = useState(null);
	const [shippingType, setShippingType] = useState("Inpost Paczkomaty");

	useEffect(() => {
		GetProfil("customers/get", METHOD.GET);
		GetAddresses("addresses/all", METHOD.GET);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (addresses) {
			setShippingIdx(0);
			setInvoiceIdx(0);
		}
	}, [addresses]);

	const AddressChooser = ({ idx, SetIdx }) => {
		return (
			<>
				{" "}
				{addresses && (
					<div>
						<select
							onChange={(e) => SetIdx(e.target.value)}
							value={idx ?? 0}
						>
							{addresses.map((a, idx) => {
								return (
									<option key={a.id} value={idx}>{`${a.city} ${
										a.street
									} ${a.number}${
										a.subNumber ? "/" + a.subNumber : ""
									} ${a.postalCode} `}</option>
								);
							})}
						</select>
						<button>Dodaj nowy adres</button>
						{
							<form>
								<label>
									Miasto
									<input value={addresses[idx]?.city ?? ""} disabled />
								</label>{" "}
								<label>
									Ulica
									<input
										value={addresses[idx]?.street ?? ""}
										disabled
									/>
								</label>{" "}
								<label>
									Numer domu
									<input
										value={addresses[idx]?.number ?? ""}
										disabled
									/>
								</label>{" "}
								<label>
									Numer lokalu
									<input
										value={addresses[idx]?.subNumber ?? ""}
										disabled
									/>
								</label>{" "}
								<label>
									Kod pocztowy
									<input
										value={addresses[idx]?.postalCode ?? ""}
										disabled
									/>
								</label>
							</form>
						}
					</div>
				)}
			</>
		);
	};

	const OnBuy = () => {};

	return (
		<div className="wholePage">
			<h1>Informacje dodatkowe</h1>
			<h3>Profil:</h3>
			{profil && (
				<div>
					<p>{profil.name}</p>
					<p>{profil.surname}</p>
				</div>
			)}
			<h3>Adres dostawy:</h3>
			<AddressChooser idx={shippingIdx} SetIdx={setShippingIdx} />
			<h3>Typ dostawy:</h3>
			<div onChange={(e) => setShippingType(e.target.value)}>
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Inpost Paczkomaty"}
					defaultChecked
				/>{" "}
				Inpost Paczkomaty
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Inpost Kurier"}
				/>{" "}
				Inpost Kurier
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Kurier DHL"}
				/>{" "}
				Kurier DHL
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Odbiór osobisty"}
				/>{" "}
				Odbiór osobisty
			</div>
			<h3>Adres na fakturze:</h3>
			<AddressChooser idx={invoiceIdx} SetIdx={setInvoiceIdx} />
			<button disabled={!addresses} onClick={OnBuy}>
				Potwierdzam zakup
			</button>
		</div>
	);
};

export default CreateOrder;
