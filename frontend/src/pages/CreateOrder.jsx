import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const personalCollection = "Odbiór osobisty";
const payWithCash = "Gotówka na miejscu";

const CreateOrder = () => {
	const { CallApi: GetProfil, data: profil } = useAuthFetch();
	const { CallApi: GetAddresses, data: addresses } = useAuthFetch();
	const { CallApi: NewOrder, data: newOrderData } = useAuthFetch();
	const [shippingIdx, setShippingIdx] = useState(0);
	const [invoiceIdx, setInvoiceIdx] = useState(0);
	const [shippingType, setShippingType] = useState("Inpost Paczkomaty");
	const [paymentType, setPaymentType] = useState("Karta");

	const Navigate = useNavigate();

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

	useEffect(() => {
		if (newOrderData) {
			Navigate("/order-confirm");
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [newOrderData]);

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
						<button onClick={() => Navigate("/address/new")}>
							Dodaj nowy adres
						</button>
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

	const newOrderBody = addresses
		? JSON.stringify({
				invoiceAddressId: addresses[invoiceIdx].id,
				shippingAddressId: addresses[shippingIdx].id,
				shipmentType: shippingType,
				paymentType: paymentType,
		  })
		: null;

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
			<h3>Typ dostawy:</h3>
			<form onChange={(e) => setShippingType(e.target.value)}>
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Inpost Paczkomaty"}
					disabled={paymentType === payWithCash}
					defaultChecked
				/>{" "}
				Inpost Paczkomaty
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Inpost Kurier"}
					disabled={paymentType === payWithCash}
				/>{" "}
				Inpost Kurier
				<input
					type={"radio"}
					name={"shippingType"}
					value={"Kurier DHL"}
					disabled={paymentType === payWithCash}
				/>{" "}
				Kurier DHL
				<input
					type={"radio"}
					name={"shippingType"}
					value={personalCollection}
				/>{" "}
				Odbiór osobisty
			</form>
			<h3>Metoda płatności:</h3>
			<form onChange={(e) => setPaymentType(e.target.value)}>
				<input
					type={"radio"}
					name={"paymentType"}
					value={"Karta"}
					defaultChecked
				/>{" "}
				Karta
				<input type={"radio"} name={"paymentType"} value={"BLIK"} /> BLIK
				<input type={"radio"} name={"paymentType"} value={"Przelew"} />{" "}
				Przelew
				<input
					type={"radio"}
					name={"paymentType"}
					value={payWithCash}
					disabled={shippingType !== personalCollection}
				/>{" "}
				Gotówka na miejscu
			</form>
			<h3>Adres dostawy:</h3>
			<AddressChooser idx={shippingIdx} SetIdx={setShippingIdx} />
			<h3>Adres na fakturze:</h3>
			<AddressChooser idx={invoiceIdx} SetIdx={setInvoiceIdx} />
			<button
				disabled={!addresses}
				onClick={() => NewOrder("orders/create", METHOD.POST, newOrderBody)}
			>
				Potwierdzam zakup
			</button>
		</div>
	);
};

export default CreateOrder;
