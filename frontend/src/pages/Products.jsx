// import React, { useEffect } from "react";
// import useFetch, { METHOD } from "../utils/useFetch";
// import SingleProduct from "../components/SingleProduct";
// import { useState } from "react";

// //TODO: merge with CATEGORY Page

// const Products = () => {
//   const amountPerPage = 2;
//   const { CallApi: GetPages, data: numOfPages } = useFetch();
//   const { CallApi: GetItems, data: items } = useFetch();
//   const [page, setPage] = useState(0);

//   useEffect(() => {
//     GetPages(`items/number-of-pages/${amountPerPage}`, METHOD.GET);
//     // eslint-disable-next-line react-hooks/exhaustive-deps
//   }, [amountPerPage]);

//   useEffect(
//     () => GetItems(`items/group/${amountPerPage}/${page}`, METHOD.GET),
//     // eslint-disable-next-line react-hooks/exhaustive-deps
//     [numOfPages, page]
//   );

//   const OnChangePage = (number) => {
//     setPage(number);
//   };

//   const SpawnButtons = () => {
//     if (numOfPages) {
//       var buttonPattern = Array.from(Array(numOfPages).keys());
//       return buttonPattern.map((num) => (
//         <button key={num} onClick={() => OnChangePage(num)}>
//           {num + 1}
//         </button>
//       ));
//     }
//   };

//   return (
//     <>
//       <div className="wholePage">
//         {items?.map((item) => {
//           return <SingleProduct key={item.id} product={item} />;
//         })}
//         <SpawnButtons />
//       </div>
//     </>
//   );
// };

// export default Products;
