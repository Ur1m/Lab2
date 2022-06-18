import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";
import { ProductsTable } from "./Components/Products/ProductsTable";
import ProductList from "./Products/ProductList";


function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Navbar/>
      <ProductList/>
      </header>
    </div>
  );
}

export default App;
