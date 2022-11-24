import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import OrderHiddenInfo from "../components/OrderHiddenInfo";
import AddressInfo from "../components/AddressInfo";
import { useNavigate } from "react-router-dom";

const Account = () => {
	const Navigate = useNavigate();
	const { CallApi: GetOrders, data: orders } = useAuthFetch();
	const { CallApi: GetUserBasicInfo, data: userBasicInfo } = useAuthFetch();
	const { CallApi: GetAddresses, data: addresses } = useAuthFetch();

	useEffect(() => {
		GetOrders("orders/all", METHOD.GET);
		GetUserBasicInfo("customers/get", METHOD.GET);
		UpdateAddresses();
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	const UpdateAddresses = () => {
		GetAddresses("addresses/all", METHOD.GET);
	};

	return (
		<div className="accountPage">
			<h1>Twoje zamówienia</h1>
			<div className="orderTable">
				<div className="tableHead">
					<span>Numer zam.</span>
					<span>Wartość</span>
					<span>Status</span>
					<span>Data złożenia</span>
				</div>
				{orders &&
					orders.map((o) => {
						return (
							<>
								<span>
									Zamówienie nr {String(o.id).padStart(4, "0")}
								</span>
								<span>
									{new Intl.NumberFormat("pl-PL", {
										style: "currency",
										currency: "PLN",
									}).format(o.totalPrice)}
								</span>
								<span>{o.status}</span>
								<span>
									{
										new Date(o.creationDate)
											.toISOString()
											.split("T")[0]
									}
								</span>
								<OrderHiddenInfo order={o} />
							</>
						);
					})}
			</div>

			<h1>Twój profil</h1>
			{userBasicInfo?.name}
			{userBasicInfo?.surname}
			<button onClick={() => Navigate("/profil")}>Edytuj profil</button>

			<h1>Twoje adresy</h1>
			{addresses &&
				addresses.map((a) => {
					return (
						<AddressInfo
							key={a.id}
							address={a}
							RefreshOnDelete={UpdateAddresses}
						/>
					);
				})}
			<button onClick={() => Navigate("/address/new")}>Nowy adres</button>
		</div>
	);
};

export default Account;
