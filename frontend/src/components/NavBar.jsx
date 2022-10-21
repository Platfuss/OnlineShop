// import { NavLink } from "react-router-dom";
import React from "react";
import { NavLink } from "react-router-dom";

const NavBar = () => {
	return (
		<nav>
			<NavLink end to={"/"}>
				<h1 className="logo">Misz Masz</h1>
			</NavLink>
			<ul className="menu">
				<li>
					<div>Menu</div>
					<MenuExpander />
				</li>
				<li>
					<div>Nowości</div>
				</li>
				<li className="contact">
					<NavLink end to={"/contact"}>
						Kontakt
					</NavLink>
				</li>
			</ul>
		</nav>
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
				<div>Do kupienia</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/budowlane"}>
							Budowlane
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/zabawki"}>
							Zabawki
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/spozywcze"}>
							Spożywcze
						</NavLink>
					</li>
				</ul>
			</li>
			<li>
				<div>Do wypożyczenia</div>
				<ul className="submenu2">
					<li>
						<NavLink end to={"/products/sportowe"}>
							Sportowe
						</NavLink>
					</li>
					<li>
						<NavLink end to={"/products/agd"}>
							AGD
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
