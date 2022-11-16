import React from "react";

const AddressInfo = ({ address }) => {
	return (
		<div>
			{address.city}
			{address.street}
			{address.number}
			{address.subNumber ? `/${address.subNumber}` : ""}
			{address.postalCode}
		</div>
	);
};

export default AddressInfo;
