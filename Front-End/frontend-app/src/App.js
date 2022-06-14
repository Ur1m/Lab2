import CategoryList from "./Category/CategoryList";
import { Navbar } from "./Components/Navbar/Navbar";
import { ProductsTable } from "./Components/Products/ProductsTable";


function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Navbar/>
      <CategoryList/>
      </header>
    </div>
  );
}

export default App;
