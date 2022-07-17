import AttributeList from "./Atributes/AttributeList";
import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";
import { ProductsTable } from "./Components/Products/ProductsTable";
import ProductList from "./Products/ProductList";
import logo from "./logo.svg";
import "./App.css";
import React from "react";

// Imports from SuperTokens
import ThirdPartyEmailPassword, {
  Facebook,
 Google,
} from "supertokens-auth-react/recipe/thirdpartyemailpassword";

import Session from "supertokens-auth-react/recipe/session";

// import react-router-dom components

import { Routes, BrowserRouter as Router, Route } from "react-router-dom";

// import SuperTokens Auth routes

import SuperTokens, {
 getSuperTokensRoutesForReactRouterDom,
} from "supertokens-auth-react";

import Home from "./Home";

// SuperTokens INIT

SuperTokens.init({
 appInfo: {
   appName: "LearNow",
   apiDomain: "http://localhost:5000",
   websiteDomain: "http://localhost:3000",
 },
 recipeList: [
   ThirdPartyEmailPassword.init({
     signInAndUpFeature: {
       providers: [
         Google.init(),
         Facebook.init(),
       ],
     },
   }),
   Session.init(),
 ],
});


function App() {
  return (
    <div className="App">
      <Router>
       <Routes>
         {/*This renders the login UI on the /auth route*/}
         {getSuperTokensRoutesForReactRouterDom(require("react-router-dom"))}

         <Route path="/" element={<Home />} />

       </Routes>
     </Router>

      { /* <header className="App-header">
     
      <AttributeList/>
  </header> */}
    </div>
  );
}

export default App;
