import React from "react";
import PageChanger from "./pages/PageChanger";
import Footer from "./components/Footer";
import Header from "./components/Header";
import LoginKeeper from "./utils/LoginKeeper";

export default function App() {
	return (
		<>
			<LoginKeeper />
			<Header />
			<PageChanger />
			<Footer />
		</>
	);
}
