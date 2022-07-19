import LoginComponent from "./Account/Login/LoginComponent";
import AttributeList from "./Atributes/AttributeList";
import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";
import React, { Fragment, useEffect, useState } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  RouteComponentProps,
  withRouter,
  useLocation,
  Routes,
  BrowserRouter,
} from "react-router-dom";
import { ProductsTable } from "./Components/Products/ProductsTable";
import { Home } from "./Components/Home/Home";
import ProductList from "./Products/ProductList";
import "./Components/Home/home.css";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />}></Route>
          <Route path="/products" element={<ProductList />}></Route>
        </Routes>
      </header>
    </div>
  );
}

export default App;
