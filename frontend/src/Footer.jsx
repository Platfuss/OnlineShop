import React from "react";

const Footer = () => {
	return (
		<footer>
			<div className="content">
				<div className="line"></div>
				<div>
					<h3>Warunki zakupów</h3>
					<ul>
						<li>Regulamin</li>
						<li>Sposoby płatności</li>
						<li>Zwroty i reklamacje</li>
						<li>Program rabatowy</li>
					</ul>
				</div>

				<div>
					<h3>Pomoc</h3>
					<ul>
						<li>Kontakt</li>
						<li>Częste pytania</li>
					</ul>
				</div>

				<div>
					<h3>+48 530 965 590</h3>
					<p>
						Poniedziałek - piątek: 7<sup>30</sup> - 21
						<sup>00</sup>
					</p>
					<p>
						Sobota: 9<sup>00</sup> - 16
						<sup>00</sup>
					</p>

					<h3>Napisz do nas</h3>
					<p>michal.stanislaw.drelich@gmail.com</p>
				</div>
			</div>
		</footer>
	);
};

export default Footer;
