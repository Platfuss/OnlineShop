//TODO: alert with not enough items pops up to often
import React, { useEffect, useState } from "react";
import { METHOD } from "../utils/useFetch";
import useAuthFetch from "../utils/useAuthFetch";
import Img64Base from "../utils/Img64Base";
import { useNavigate, NavLink } from "react-router-dom";
import useAuth from "../utils/useAuth";

const Cart = () => {
  const Navigate = useNavigate();
  const { CallApi: GetItemsInCart, data: itemsInCart } = useAuthFetch();
  const { CallApi: DeleteItemFromCart, isLoading: isDeletingEntry } =
    useAuthFetch();
  const {
    CallApi: UpdateEntry,
    isLoading: isUpdatingEntry,
    data: wasValidAmount,
  } = useAuthFetch();
  const { CallApi: GetCartTotalPrice, data: cartTotalPrice } = useAuthFetch();

  const { setCartTotal } = useAuth();
  //const [serverItemAmounts, setServerItemAmounts] = useState({});
  const [webItemAmounts, setWebItemAmounts] = useState({});

  useEffect(
    () => GetItemsInCart("carts/get", METHOD.GET),
    // eslint-disable-next-line react-hooks/exhaustive-deps
    []
  );

  useEffect(
    () => {
      if (isUpdatingEntry === false && isDeletingEntry === false) {
        GetItemsInCart("carts/get", METHOD.GET);
        GetCartTotalPrice("carts/total-price", METHOD.GET);
      }
    },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [isUpdatingEntry, isDeletingEntry]
  );

  useEffect(() => {
    if (cartTotalPrice === 0 || cartTotalPrice) {
      setCartTotal(cartTotalPrice);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [cartTotalPrice]);

  useEffect(() => {
    if (wasValidAmount === false) {
      // alert("Przekroczono liczbę dostępnych produktów");
      //TODO: check whats wrong
    }
  }, [wasValidAmount]);

  useEffect(() => {
    let itemAmounts = {};
    if (itemsInCart) {
      for (const itemIndex in itemsInCart) {
        var item = itemsInCart[itemIndex];
        itemAmounts[item.itemId] = item.amount;
      }
    }
    setWebItemAmounts(itemAmounts);
  }, [itemsInCart]);

  const OnAmountConfirmed = (itemId) => {
    UpdateEntry(
      "carts/update",
      METHOD.PATCH,
      JSON.stringify({
        itemId: itemId,
        amount: webItemAmounts[itemId],
      })
    );
  };

  return (
    <div className="cart">
      <h1>Koszyk</h1>
      {itemsInCart?.length ? (
        <div className="tableContainer">
          <table>
            <tr>
              <th></th>
              <th>Produkt</th>
              <th>Cena</th>
              <th>Ilość</th>
              <th>Wartość</th>
              <th></th>
            </tr>
            {itemsInCart?.map((it) => {
              return (
                <tr key={it.itemId}>
                  <td>
                    <Img64Base src={it.image}></Img64Base>
                  </td>

                  <td>
                    <NavLink end to={`/products/details/${it.itemId}`}>
                      {it.name}
                    </NavLink>
                  </td>

                  <td>
                    {new Intl.NumberFormat("pl-PL", {
                      style: "currency",
                      currency: "PLN",
                    }).format(it.price)}
                  </td>

                  <td>
                    <input
                      type={"number"}
                      min={0}
                      max={99}
                      value={webItemAmounts[it.itemId] || 0}
                      onBlur={() => OnAmountConfirmed(it.itemId)}
                      onChange={(e) => {
                        var newAmounts = {
                          ...webItemAmounts,
                          [it.itemId]: parseInt(e.target.value),
                        };
                        setWebItemAmounts(newAmounts);
                      }}
                    ></input>
                  </td>

                  <td>
                    {new Intl.NumberFormat("pl-PL", {
                      style: "currency",
                      currency: "PLN",
                    }).format(it.price * it.amount)}
                  </td>

                  <td>
                    <button
                      onClick={() =>
                        DeleteItemFromCart(`carts/${it.itemId}`, METHOD.DELETE)
                      }
                    >
                      X
                    </button>
                  </td>
                </tr>
              );
            })}
          </table>
          <button
            disabled={Object.keys(webItemAmounts).length === 0}
            onClick={() => Navigate("/create-order")}
          >
            Zamawiam
          </button>
        </div>
      ) : (
        <>
          <h3>Twój koszyk jest pusty</h3>
          <button onClick={() => Navigate(-1)}>Powrót</button>
        </>
      )}
    </div>
  );
};

export default Cart;
