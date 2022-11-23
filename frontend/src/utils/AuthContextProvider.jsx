import React from "react";
import { createContext, useState } from "react";

const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
	const [auth, setAuth] = useState(false);
	const [cartTotal, setCartTotal] = useState(0);

	return (
		<AuthContext.Provider value={{ auth, setAuth, cartTotal, setCartTotal }}>
			{children}
		</AuthContext.Provider>
	);
};

export default AuthContext;
export { AuthContextProvider };
