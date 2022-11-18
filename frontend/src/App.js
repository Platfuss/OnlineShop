import React from "react";
import PageChanger from "./PageChanger";
import Footer from "./Footer";
import Header from "./Header";
//import LoginKeeper from "./utils/LoginKeeper";

export default function App() {
	return (
		<>
			{/* <LoginKeeper /> */}
			<Header />
			<PageChanger />
			<Footer />
		</>
	);
}
