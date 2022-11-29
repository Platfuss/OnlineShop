// import { NavLink } from "react-router-dom";
import React from "react";
import { NavLink } from "react-router-dom";

const NavBar = () => {
	return (
		<ul className="menuBar">
			<li>
				<div>Menu</div>
				<MenuExpander />
			</li>
			<li>
				<div>Nowości</div>
			</li>
			<li>
				<div>Promocje</div>
			</li>
			<li className="contact">
				<NavLink end to={"/contact"}>
					Kontakt
				</NavLink>
			</li>
		</ul>
	);
};

const MenuExpander = () => {
	return (
		<ul className="submenu">
			<li className="allItems">
				<NavLink end to={"/products"}>
					Wszystkie
				</NavLink>
			</li>

			<li>
				<div>Rozrywka</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/board-games"}>
							Gry planszowe
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/music"}>
							Muzyka
						</NavLink>
					</li>
				</ul>
			</li>

			<li>
				<div>Artykuły spożywcze</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/cakes"}>
							Ciasta
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/sweets"}>
							Cukierki
						</NavLink>
					</li>
				</ul>
			</li>
		</ul>
	);
};

export default NavBar;
