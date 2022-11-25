import React from "react";
import { useEffect } from "react";
import useAuthFetch, { METHOD } from "../utils/useAuthFetch";
import { useNavigate } from "react-router-dom";
import { useState } from "react";

const AddressInfo = ({ address, RefreshOnDelete }) => {
  const Navigate = useNavigate();
  const { CallApi: OnDelete, isLoading } = useAuthFetch();
  const [clickedDelete, setClickedDelete] = useState(false);

  useEffect(() => {
    if (RefreshOnDelete && isLoading === false && clickedDelete) {
      RefreshOnDelete();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isLoading]);

  return (
    <div className="addressInfo">
      <p>{address.city}</p>
      <p>{address.street}</p>
      <p>
        {address.number}
        {address.subNumber ? `/${address.subNumber}` : ""}
      </p>
      <p>{address.postalCode}</p>
      {RefreshOnDelete && (
        <div className="editDeleteButtonsContainer">
          <button onClick={() => Navigate(`/address/${address.id}`)}>
            Edytuj
          </button>

          <button
            onClick={() => {
              setClickedDelete(true);
              OnDelete(`addresses/${address.id}`, METHOD.DELETE);
            }}
          >
            Usuń
          </button>
        </div>
      )}
    </div>
  );
};

export default AddressInfo;
