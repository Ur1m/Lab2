import AttributeList from "./Atributes/AttributeList";
import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";
import { ProductsTable } from "./Components/Products/ProductsTable";
import {Home} from "./Components/Home/Home";
import ProductList from "./Products/ProductList";


function App() {
  return (
    <div className="App">

      <header className="App-header">
      <Navbar/>
      <Home/>
      </header>
     { /* <header className="App-header">
     
      <AttributeList/>
  </header> */ }
    </div>
  );
}

export default App;
