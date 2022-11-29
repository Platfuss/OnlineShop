import React from "react";
import { NavLink } from "react-router-dom";
import AddressInfo from "./AddressInfo";

const OrderHiddenInfo = ({ order }) => {
	return (
		<div className="orderHiddenInfo">
			<h2>Szczegóły zamówienia nr {String(order.id).padStart(4, "0")}</h2>
			<div className="orderAddresses">
				<div>
					<h3>Adres na fakturze:</h3>
					<AddressInfo address={order.invoiceAddress} />
				</div>
				<div>
					<h3>Adres dostawy:</h3>
					<AddressInfo address={order.shippingAddress} />
				</div>
			</div>

			<h3>Zamówione przedmioty:</h3>
			<table>
				<thead>
					<tr>
						<th>Produkt</th>
						<th>Ilość</th>
						<th>Cena za sztukę</th>
						<th>Wartość</th>
					</tr>
				</thead>

				<tbody>
					{order.orderedItems.map((oi, idx) => {
						return (
							<tr key={idx}>
								<td>
									<NavLink end to={`/products/details/${oi.id}`}>
										{oi.name}
									</NavLink>
								</td>
								<td>{oi.amount} szt. </td>
								<td>
									{new Intl.NumberFormat("pl-PL", {
										style: "currency",
										currency: "PLN",
									}).format(oi.price)}
								</td>
								<td>
									{new Intl.NumberFormat("pl-PL", {
										style: "currency",
										currency: "PLN",
									}).format(oi.price * oi.amount)}
								</td>
							</tr>
						);
					})}
				</tbody>
				<tfoot>
					<tr className="footBreak"></tr>
					<tr>
						<td></td>
						<td></td>
						<td>Suma:</td>
						<td>
							{new Intl.NumberFormat("pl-PL", {
								style: "currency",
								currency: "PLN",
							}).format(order.totalPrice)}
						</td>
					</tr>
				</tfoot>
			</table>
		</div>
	);
};

export default OrderHiddenInfo;
