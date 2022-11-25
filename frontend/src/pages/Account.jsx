import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import OrderHiddenInfo from "../components/OrderHiddenInfo";
import AddressInfo from "../components/AddressInfo";
import { useNavigate } from "react-router-dom";
import { useState } from "react";

const Account = () => {
  const Navigate = useNavigate();
  const [choosenOrder, setChoosenOrder] = useState(null);
  const { CallApi: GetOrders, data: orders } = useAuthFetch();
  const { CallApi: GetUserBasicInfo, data: userBasicInfo } = useAuthFetch();
  const { CallApi: GetAddresses, data: addresses } = useAuthFetch();

  useEffect(() => {
    GetOrders("orders/all", METHOD.GET);
    GetUserBasicInfo("customers/get", METHOD.GET);
    UpdateAddresses();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const UpdateAddresses = () => {
    GetAddresses("addresses/all", METHOD.GET);
  };

  return (
    <div className="accountPage">
      <h1>Twoje zamówienia</h1>
      <div className="orderTable">
        <div className="tableHead">
          <span>Numer zam.</span>
          <span>Wartość</span>
          <span>Status</span>
          <span>Data złożenia</span>
        </div>
        <div className="line"></div>
        {orders &&
          orders.map((o) => {
            return (
              <>
                <button
                  className="orderBasicInfo"
                  onClick={() => setChoosenOrder(o)}
                >
                  <span>Zamówienie nr {String(o.id).padStart(4, "0")}</span>
                  <span>
                    {new Intl.NumberFormat("pl-PL", {
                      style: "currency",
                      currency: "PLN",
                    }).format(o.totalPrice)}
                  </span>
                  <span>{o.status}</span>
                  <span>
                    {new Date(o.creationDate).toISOString().split("T")[0]}
                  </span>
                </button>
              </>
            );
          })}
        {choosenOrder && <OrderHiddenInfo order={choosenOrder} />}
      </div>

      <h1>Twoje adresy</h1>
      <div className="addressesContainer">
        {addresses &&
          addresses.map((a) => {
            return (
              <AddressInfo
                key={a.id}
                address={a}
                RefreshOnDelete={UpdateAddresses}
              />
            );
          })}
        <div className="breakLine"></div>
        <button onClick={() => Navigate("/address/new")}>Nowy adres</button>
      </div>

      <h1>Twój profil</h1>
      <div className="profileInfo">
        <p>{`Imię: ${userBasicInfo?.name}`}</p>
        <p>{`Nazwisko: ${userBasicInfo?.surname}`}</p>
        <button onClick={() => Navigate("/profil")}>Edytuj profil</button>
      </div>
    </div>
  );
};

export default Account;
