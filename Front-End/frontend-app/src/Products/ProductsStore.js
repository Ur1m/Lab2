import axios from "axios";
import { makeAutoObservable, runInAction } from "mobx";

export default class ProductStore {
  selectedProduct = undefined;
  editmode = false;
  detailsmode = false;
  productsRegistry = new Map();
  constructor() {
    makeAutoObservable(this);
  }
  loadProducts = async () => {
    try {
      const products = await (
        await axios.get("https://localhost:5002/api/product")
      ).data;
      runInAction(() => {
        products.forEach((prod) => {
          this.productsRegistry.set(prod.id, prod);
        });
      });
    } catch (error) {
      console.log(error);
    }
  };
  get products() {
    return Array.from(this.productsRegistry.values());
  }
  openDetails = (id) => {
    this.selectProduct(id);
    this.detailsmode = true;
  };
  closeDetails = () => {
    this.detailsmode = false;
  };
  selectProduct = (id) => {
    this.selectedProduct = this.productsRegistry.get(id);
  };
  canceleSelectedProduct = () => {
    this.selectedProduct = undefined;
  };

  openForm = (id) => {
    id ? this.selectProduct(id) : this.canceleSelectedProduct();
    this.editmode = true;
  };
  closeForm = () => {
    this.editmode = false;
  };
  createProduct = async (prod) => {
    try {
      await axios.post("https://localhost:5002/api/product", prod);
      runInAction(() => {
        this.productsRegistry.set(prod.id, prod);
        this.selectedProduct = prod;
        this.editmode = false;
      });
    } catch (error) {
      console.log(error);
    }
  };
  updateProduct = async (product) => {
    try {
      await axios.put("https://localhost:5002/api/product", product);
      runInAction(() => {
        this.productsRegistry.set(product.id, product);
        this.selectedProduct = product;
        this.editmode = false;
      });
    } catch (error) {
      console.log(error);
    }
  };
  deleteProduct = async (id) => {
    try {
      await axios.delete(`https://localhost:5002/api/product/${id}`);
      runInAction(() => {
        //this.pacientat=[...this.pacientat.filter(a => a.pacient_Id !== id)]
        this.productsRegistry.delete(id);
        if (this.selectedProduct.id == id) this.canceleSelectedProduct();
      });
    } catch (error) {
      console.log(error);
    }
  };
}
