import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch, { METHOD } from "../utils/useFetch";
import SingleProduct from "../components/SingleProduct";
import { useState } from "react";

const Category = () => {
  const amountPerPage = 8;
  const params = useParams();
  const { CallApi: GetPages, data: numOfPages } = useFetch();
  const { CallApi: GetItems, data: items } = useFetch();
  const [page, setPage] = useState(0);

  const category = params.category ?? null;

  useEffect(() => {
    GetPages(
      `items/group/number-of-pages/${amountPerPage}${
        category ? `?category=${category}` : ""
      }`,
      METHOD.GET
    );
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [amountPerPage, params]);

  useEffect(
    () =>
      GetItems(
        `items/group/${amountPerPage}/${page}${
          category ? `?category=${category}` : ""
        }`,
        METHOD.GET
      ),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [numOfPages, page, params]
  );

  const OnChangePage = (number) => {
    setPage(number);
  };

  const SpawnButtons = () => {
    if (numOfPages) {
      var buttonPattern = Array.from(Array(numOfPages).keys());
      return buttonPattern.map((num) => (
        <div className="buttonList">
          <button key={num} onClick={() => OnChangePage(num)}>
            {num + 1}
          </button>
        </div>
      ));
    }
  };

  return (
    <>
      <SpawnButtons />
      <div className="listOfItems">
        {items?.map((item) => {
          return <SingleProduct key={item.id} product={item} />;
        })}
      </div>
      <div className="breakLine"></div>
      <SpawnButtons />
    </>
  );
};

export default Category;
