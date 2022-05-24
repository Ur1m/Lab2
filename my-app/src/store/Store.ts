import { createContext, useContext } from "react";
import CategoryStore from "../Category/CategoryStore";

interface Store {
   CategoryStore:  CategoryStore;
    
}

export const store: Store = {
   CategoryStore:new CategoryStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}

