import React, { useEffect } from "react";
import SingleProduct from "../components/SingleProduct";
import useFetch, { METHOD } from "../utils/useFetch";

const Home = () => {
  const {
    CallApi: FetchNewests,
    data: newests,
    isLoading: isNewestsLoading,
  } = useFetch();
  const { CallApi: FetchRecommended, data: recommended } = useFetch();

  useEffect(() => {
    FetchNewests("items/group/8/0", METHOD.GET);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    if (isNewestsLoading === false) {
      FetchRecommended("items/group/8/0?onlyrecommended=true", METHOD.GET);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isNewestsLoading]);

  return (
    <>
      <div>
        {newests && <h1>Nowości!</h1>}
        <div className="listOfItems">
          {newests?.map((item) => (
            <SingleProduct key={item.id} product={item} />
          ))}
        </div>
      </div>

      <div>
        {recommended && <h1>Rekomendowane</h1>}
        <div className="listOfItems">
          {recommended?.map((item) => (
            <SingleProduct key={item.id} product={item} />
          ))}
        </div>
      </div>
    </>
  );
};

export default Home;
