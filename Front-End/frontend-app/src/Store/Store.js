import { createContext, useContext } from "react";
import ProductStore from "../Products/ProductsStore";




export const store = {
   ProductStore:new ProductStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}

