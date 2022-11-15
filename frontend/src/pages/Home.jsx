import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD } from "../utils/useFetch";

const Home = () => {
	const { CallApi: FetchNewests, data: newests } = useFetch();
	const { CallApi: FetchRecommended, data: recommended } = useFetch();

	useEffect(
		() => {
			FetchNewests("items/group/8/0", METHOD.GET);
			FetchRecommended("items/group/8/0?onlyrecommended=true", METHOD.GET);
		},
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[]
	);

	return (
		<>
			<div className="wholePage">
				<h1>Nowości!</h1>
				{newests?.map((item) => (
					<SingleProduct key={item.id} product={item} />
				))}
				<h1>Rekomendowane</h1>
				{recommended?.map((item) => (
					<SingleProduct key={item.id} product={item} />
				))}
			</div>
		</>
	);
};

export default Home;
