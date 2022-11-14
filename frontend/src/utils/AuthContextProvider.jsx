import React from "react";
import { createContext, useState } from "react";

const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
	const [auth, setAuth] = useState(false);

	return (
		<AuthContext.Provider value={{ auth, setAuth }}>
			{children}
		</AuthContext.Provider>
	);
};

export default AuthContext;
export { AuthContextProvider };
