import React from "react";
import { useNavigate } from "react-router-dom";

const OrderConfirm = () => {
	const Navigate = useNavigate();

	return (
		<div className="wholePage">
			<h1>GRATULACJE!</h1>
			<p>
				Właśnie udało się Państwu zakupić nieistniejące przedmioty w
				nieistniejącym sklepie!
			</p>
			<p>Miłego dnia i zapraszamy na kolejne "zakupy"</p>
			<br />
			<button onClick={() => Navigate("/")}>Wróć na stronę domową</button>
		</div>
	);
};

export default OrderConfirm;
