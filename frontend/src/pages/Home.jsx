import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD } from "../utils/useFetch";
import PropagateLoader from "react-spinners/PropagateLoader";

const Home = () => {
	const {
		CallApi: FetchNewests,
		data: newests,
		isLoading: isFetchingNewests,
	} = useFetch();
	const {
		CallApi: FetchRecommended,
		data: recommended,
		isLoading: isFetchingRecommended,
	} = useFetch();

	useEffect(() => {
		FetchNewests("items/group/6/0", METHOD.GET);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (!isFetchingNewests && newests) {
			FetchRecommended("items/group/3/1?onlyrecommended=true", METHOD.GET);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isFetchingNewests]);

	return (
		<div className="mainContent">
			<div>
				<h1>Nowości!</h1>
				<div className="loaderHolder">
					<PropagateLoader loading={isFetchingNewests} />
				</div>
				<div className="listOfItems">
					{newests?.map((item) => (
						<SingleProduct key={item.id} product={item} />
					))}
				</div>
			</div>

			<div>
				{newests && <h1>Rekomendowane</h1>}
				<div className="loaderHolder">
					<PropagateLoader loading={isFetchingRecommended} />
				</div>
				<div className="listOfItems">
					{recommended?.map((item) => (
						<SingleProduct key={item.id} product={item} />
					))}
				</div>
			</div>
		</div>
	);
};

export default Home;
