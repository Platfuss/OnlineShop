import React from "react";
import { NavLink } from "react-router-dom";
import AddressInfo from "./AddressInfo";

const OrderHiddenInfo = ({ order }) => {
	return (
		<div>
			<h3>Adres na fakturze:</h3>
			<AddressInfo address={order.invoiceAddress} />
			<h3>Adres dostawy:</h3>
			<AddressInfo address={order.shippingAddress} />
			<h3>Zamówione przedmioty:</h3>
			{order.orderedItems.map((oi, idx) => {
				return (
					<div key={idx}>
						<NavLink end to={`/products/details/${oi.id}`}>
							{oi.name}
						</NavLink>
						{oi.amount} szt.
						{oi.price} zł
						{oi.price * oi.amount} zł
					</div>
				);
			})}
			{order.totalPrice}
		</div>
	);
};

export default OrderHiddenInfo;
