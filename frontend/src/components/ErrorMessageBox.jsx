import React from "react";

const ErrorMessageBox = ({ lackingItems }) => {
	return (
		<div className="errorMessageBox">
			<p>Ilość produktów w koszyku przekracza dostępny stan magazynowy.</p>
			<p>Aktualnie dostępne ilości to:</p>
			<p></p>
			<ul>
				{lackingItems.map((item, idx) => {
					var name = Object.keys(item);
					return <li key={idx}>{`${name} - ${item[name]} szt.`}</li>;
				})}
			</ul>
		</div>
	);
};

export default ErrorMessageBox;
