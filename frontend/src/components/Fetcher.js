import React, { Component } from "react";

export default class Fetcher extends Component {
  constructor(props) {
    super(props);

    this.state = {
      items: [],
      isDataLoaded: false,
    };
  }

  componentDidMount() {
    fetch("https://localhost:7177/api/Adress/api/Adress/GetAddress?id=2")
      .then((result) => result.json())
      .then((json) => {
        this.setState({
          items: json,
          isDataLoaded: true,
        });
      });
  }

  render() {
    const { isDataLoaded, items } = this.state;
    console.log(isDataLoaded);
    if (!isDataLoaded) {
      return (
        <div>
          <h1>Something's wrong with API</h1>
        </div>
      );
    }

    console.log(items);
    const { id, city, street, postalCode } = items;
    return (
      <div>
        <h1>Data:</h1>
        <h5>
          {id}, {city}, {street}, {postalCode}
        </h5>
      </div>
    );
  }
}
