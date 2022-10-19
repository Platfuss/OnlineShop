import React from "react";
import Fetcher, { METHODS } from "./components/Fetcher";

export default function App() {
  const body = JSON.stringify({
    title: "test product",
    price: 13.5,
    description: "lorem ipsum set",
    image: "https://i.pravatar.cc",
    category: "electronic",
  });

  const { data, isLoaded } = Fetcher(
    "https://fakestoreapi.com/products",
    METHODS.POST,
    body
  );
  console.log(data);
  return <h1>Hello</h1>;
}
