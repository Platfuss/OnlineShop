import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import useAuthFetch from "../utils/useAuthFetch";
import { METHOD } from "../utils/useFetch";
import { useNavigate } from "react-router-dom";

const ProfilEditor = () => {
	const Navigate = useNavigate();
	const { CallApi: GetProfil, data: profil } = useAuthFetch();
	const { CallApi: SubmitProfil, status: profilSubmitStatus } = useAuthFetch();

	const [name, setName] = useState("");
	const [surname, setSurname] = useState("");

	var profilBody = JSON.stringify({
		name: name,
		surname: surname,
	});

	useEffect(() => {
		GetProfil(`customers/get`, METHOD.GET);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (profil) {
			setName(profil.name);
			setSurname(profil.surname);
		}
	}, [profil]);

	useEffect(() => {
		if (profilSubmitStatus === 200) {
			Navigate("/account");
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [profilSubmitStatus]);

	return (
		<div className="formContainer">
			<h1>Edycja profilu</h1>
			<form>
				<label>
					Imię
					<input
						value={name}
						onChange={(e) => {
							setName(e.target.value);
						}}
					/>
				</label>{" "}
				<label>
					Nazwisko
					<input
						value={surname}
						onChange={(e) => {
							setSurname(e.target.value);
						}}
					/>
				</label>
			</form>
			<div>
			<button
				onClick={() =>
					SubmitProfil("customers/update", METHOD.PATCH, profilBody)
				}
				disabled={!(name && surname)}
			>
				Aktualizuj
			</button>
			<button onClick={() => Navigate(-1)}>Powrót</button>
			</div>
		</div>
	);
};

export default ProfilEditor;
