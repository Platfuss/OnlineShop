import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch, { METHOD } from "../utils/useFetch";
import SingleProduct from "../components/SingleProduct";
import { useState } from "react";

const Category = () => {
	const amountPerPage = 1;
	const param = useParams();
	const { CallApi: GetPages, data: numOfPages } = useFetch();
	const { CallApi: GetItems, data: items } = useFetch();
	const [page, setPage] = useState(0);

	useEffect(() => {
		GetPages(
			`items/number-of-pages/${amountPerPage}?category=${param.category}`,
			METHOD.GET
		);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [amountPerPage, param]);

	useEffect(
		() =>
			GetItems(
				`items/group/${amountPerPage}/${page}?category=${param.category}`,
				METHOD.GET
			),
		// eslint-disable-next-line react-hooks/exhaustive-deps
		[numOfPages, page, param]
	);

	const OnChangePage = (number) => {
		setPage(number);
	};

	const SpawnButtons = () => {
		if (numOfPages) {
			var buttonPattern = Array.from(Array(numOfPages).keys());
			return buttonPattern.map((num) => (
				<button key={num} onClick={() => OnChangePage(num)}>
					{num + 1}
				</button>
			));
		}
	};

	return (
		<>
			<div className="wholePage">
				{items?.map((item) => {
					return <SingleProduct key={item.id} product={item} />;
				})}
				<SpawnButtons />
			</div>
		</>
	);
};

export default Category;
