import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch, { METHOD } from "../utils/useFetch";
import SingleProduct from "../components/SingleProduct";
import { useState } from "react";
import RiseLoader from "react-spinners/RiseLoader";

const Category = () => {
	const amountPerPage = 8;
	const params = useParams();

	const {
		CallApi: GetNumOfPages,
		data: numOfPages,
		isLoading: isNumOfPagesLoading,
	} = useFetch();

	const {
		CallApi: GetItems,
		data: items,
		isLoading: isItemsLoading,
	} = useFetch();

	const [page, setPage] = useState(0);

	const category = params.category ?? null;

	useEffect(() => setPage(-1), [category]);

	useEffect(() => {
		GetNumOfPages(
			`items/group/number-of-pages/${amountPerPage}${
				category ? `?category=${category}` : ""
			}`,
			METHOD.GET
		);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [amountPerPage, category]);

	useEffect(
		() => {
			if (page >= 0) {
				GetItems(
					`items/group/${amountPerPage}/${page}${
						category ? `?category=${category}` : ""
					}`,
					METHOD.GET
				);
			} else {
				setPage(0);
			}
		},
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[page]
	);

	const SpawnButtons = () => {
		if (numOfPages) {
			var buttonPattern = Array.from(Array(numOfPages).keys());
			return (
				<div className="buttonList">
					{buttonPattern.map((num) => {
						return (
							<button key={num} onClick={() => setPage(num)}>
								{num + 1}
							</button>
						);
					})}
				</div>
			);
		}
	};

	return (
		<>
			{isNumOfPagesLoading ? (
				<div className="middleLoader">
					<RiseLoader />
				</div>
			) : (
				<div className="mainContent">
					<SpawnButtons />
					{isItemsLoading && (
						<div className="middleLoader">
							<RiseLoader />
						</div>
					)}

					{!isItemsLoading && (
						<div className="listOfItems">
							{items?.map((item) => {
								return <SingleProduct key={item.id} product={item} />;
							})}
						</div>
					)}
					<div className="breakLine" />
					<SpawnButtons />
				</div>
			)}
		</>
	);
};

export default Category;
