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
			<li>
				<NavLink end to={"/products"}>
					Wszystkie
				</NavLink>
			</li>
			<li>
				<div>Przedmioty</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/rozrywka"}>
							Rozrywka
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/zywnosc"}>
							Żywność
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/zoologia"}>
							Zoologia
						</NavLink>
					</li>
				</ul>
			</li>
			<li>
				<div>Ubrania</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/men's clothing"}>
							Ubrania męskie
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/women's clothing"}>
							Ubrania kobiece
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/imprezowe"}>
							Na imprezę
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/wirtualne"}>
							Wirtualne
						</NavLink>
					</li>
				</ul>
			</li>
		</ul>
	);
};

export default NavBar;
