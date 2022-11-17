import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import OrderHiddenInfo from "../components/OrderHiddenInfo";
import AddressInfo from "../components/AddressInfo";

const Account = () => {
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
		<div className="wholePage">
			<h2>Twoje zamówienia</h2>
			{orders &&
				orders.map((o) => {
					return (
						<div key={o.id}>
							Zamówienie nr {String(o.id).padStart(4, "0")}
							{o.totalPrice}zł
							{o.status}
							{new Date(o.creationDate).toISOString().split("T")[0]}
							<OrderHiddenInfo order={o} />
						</div>
					);
				})}
			<h2>Twój profil</h2>
			{userBasicInfo?.name}
			{userBasicInfo?.surname}

			<h2>Twoje adresy</h2>
			{addresses &&
				addresses.map((a) => {
					return (
						<AddressInfo
							key={a.id}
							address={a}
							Callback={UpdateAddresses}
						/>
					);
				})}
		</div>
	);
};

export default Account;
