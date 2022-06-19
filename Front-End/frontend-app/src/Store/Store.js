import { createContext, useContext } from "react";
import AttributeStore from "../Atributes/AttributesStore";
import ProductStore from "../Products/ProductsStore";




export const store = {
   ProductStore:new ProductStore(),
   AttributeStore:new AttributeStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}

