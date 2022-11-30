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
	const { CallApi: FetchRecommended, data: recommended } = useFetch();

	const isAllLoaded = !!newests && !!recommended;

	useEffect(() => {
		FetchNewests("items/group/8/0", METHOD.GET);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	useEffect(() => {
		if (!isFetchingNewests && newests) {
			FetchRecommended("items/group/8/0?onlyrecommended=true", METHOD.GET);
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [isFetchingNewests]);

	return (
		<div>
			<PropagateLoader loading={!isAllLoaded} />

			{isAllLoaded && (
				<div>
					<div>
						<h1>Nowości!</h1>
						<div className="listOfItems">
							{newests?.map((item) => (
								<SingleProduct key={item.id} product={item} />
							))}
						</div>
					</div>

					<div>
						<h1>Rekomendowane</h1>
						<div className="listOfItems">
							{recommended?.map((item) => (
								<SingleProduct key={item.id} product={item} />
							))}
						</div>
					</div>
				</div>
			)}
		</div>
	);
};

export default Home;
