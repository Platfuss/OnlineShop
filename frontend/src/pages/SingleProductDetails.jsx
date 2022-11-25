import React, { useEffect } from "react";
import useFetch, { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import { useNavigate, useParams } from "react-router-dom";
import Img64Base from "../utils/Img64Base";
import { useState } from "react";

const SingleProductDetails = () => {
  const Navigate = useNavigate();
  const params = useParams();
  const [visibleImageId, setVisibleImageId] = useState(0);
  const { CallApi: GetDetails, data: product } = useFetch();
  const { CallApi: AddToCart, isLoading: isAddingToCart } = useAuthFetch();

  useEffect(
    () => GetDetails(`items/${params.id}`, METHOD.GET),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    []
  );

  const cartInfo = JSON.stringify({ itemId: params.Id, amount: 1 });

  const OnButtonClick = () => {
    AddToCart("carts", METHOD.POST, cartInfo);
  };

  const OnChangeImage = (step) => {
    const imgCount = product.images.length;
    let newImageId = visibleImageId + step;
    if (visibleImageId + step < 0) {
      newImageId = imgCount - 1;
    } else if (visibleImageId + step >= imgCount) {
      newImageId = 0;
    }
    setVisibleImageId(newImageId);
  };

  return (
    <div className="singleProductPage">
      {product && (
        <>
          <figure className="imageContainer">
            <Img64Base src={product.images[visibleImageId]} />
            {product.images.length > 1 ? (
              <>
                <button className="prev" onClick={() => OnChangeImage(-1)}>
                  {"<"}
                </button>
                <button className="next" onClick={() => OnChangeImage(-1)}>
                  {">"}
                </button>
              </>
            ) : (
              <></>
            )}
          </figure>
          <div className="productOverview">
            <h3>{product.category}</h3>
            <h1>{product.name}</h1>
            <div>Cena: {product.price} zł</div>
            <button
              className="addToCartButton"
              onClick={OnButtonClick}
              disabled={isAddingToCart}
            >
              Dodaj do koszyka
            </button>
          </div>
          <div className="breakLine"></div>
          <h3>Opis produktu</h3>
          <textarea disabled value={product.description} />
          <div className="breakLine"></div>
          <button onClick={() => Navigate(-1)}>Powrót</button>
        </>
      )}
    </div>
  );
};
export default SingleProductDetails;
