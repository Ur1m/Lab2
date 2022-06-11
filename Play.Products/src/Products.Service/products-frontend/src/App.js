import { Navbar } from "./Components/Navbar/Navbar";
import { ProductsTable } from "./Components/Products/ProductsTable";

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Navbar/>
      <ProductsTable/>
      </header>
    </div>
  );
}

export default App;
