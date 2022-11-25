import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { NavLink } from "react-router-dom";
import Img64Base from "../utils/Img64Base";
import useAuth from "../utils/useAuth";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";

const SingleProduct = ({ product }) => {
  var isAvailable = product.amount;
  const route = `/products/details/${product.id}`;
  const body = JSON.stringify({
    itemId: product.id,
    amount: 1,
  });

  const [wasButtonClicked, setWasButtonClicked] = useState(false);
  const { setCartTotal } = useAuth();
  const { CallApi: AddItem, isLoading: isAddingItem } = useAuthFetch();
  const { CallApi: GetCartTotalPrice, data: cartTotalPrice } = useAuthFetch();

  const OnButtonClick = () => {
    AddItem("carts/add-item", METHOD.POST, body);
    setWasButtonClicked(true);
  };

  useEffect(() => {
    if (wasButtonClicked && isAddingItem === false) {
      GetCartTotalPrice("carts/total-price", METHOD.GET);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isAddingItem]);

  useEffect(() => {
    if (cartTotalPrice === 0 || cartTotalPrice) {
      setCartTotal(cartTotalPrice);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [cartTotalPrice]);

  return (
    <div className="singleProduct">
      <figure className="imageContainer">
        <NavLink end to={route}>
          <Img64Base
            className="singleProductImage"
            src={product.image}
          ></Img64Base>
        </NavLink>
      </figure>
      <div className="productInfo">
        <span>{product.category}</span>
        <NavLink end to={route}>
          <b>
            <span>{product.name}</span>
          </b>
        </NavLink>
        <span>{product.price} zł</span>
        <div>
          <div className={`dot ${isAvailable ? "available" : ""}`}></div>
          {isAvailable ? "Dostępne" : "Niedostępne"}{" "}
        </div>
        <div className="hiddenButtonContainer">
          <button
            onClick={OnButtonClick}
            disabled={product.amount < 1 || isAddingItem}
          >
            Dodaj do koszyka
          </button>
        </div>
      </div>
    </div>
  );
};

export default SingleProduct;
