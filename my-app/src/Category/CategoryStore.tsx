
import axios from "axios";
import { makeAutoObservable, runInAction } from "mobx";
import { ICategory } from "./ICategory";

export default class CategoryStore{
    
    selectedCategory:ICategory | undefined=undefined;
    editmode=false;
    
    detailsmode=false;
    categoryRegistry=new Map<number,ICategory>()
    constructor(){
        makeAutoObservable(this)
    }
    loadCategories= async ()=>{
       try{
        const  categories=await (await axios.get("https://localhost:5001/category")).data;
        runInAction(()=>{
            
            categories.forEach((categ:ICategory) =>{
              
                this.categoryRegistry.set(categ.categoryId,categ);
        })
        
        })
       }
       catch(error){
           console.log(error);
       }
    }
    get categories(){
        return Array.from(this.categoryRegistry.values());
    }
    openDetails=(id:number)=>{
        this.selectCategory(id);
        this.detailsmode=true;
    }
    closeDetails=()=>{
        this.detailsmode=false;
    }
    selectCategory=(id:number)=>{
      this.selectedCategory=this.categoryRegistry.get(id);
    }
    canceleSelectedCategory=()=>{
        this.selectedCategory=undefined;
    }
   
    openForm=(id?:number)=>{
        id? this.selectCategory(id) : this.canceleSelectedCategory();
        this.editmode=(true);
    }
    closeForm=()=>{
        this.editmode=false;
    }
    createCategory=async(categ :ICategory)=>{
        
        try{
            await axios.post("https://localhost:5001/category");
            runInAction(()=>{
                this.categoryRegistry.set(categ.categoryId,categ);
                this.selectedCategory=categ;
                this.editmode=false;
               
            })
        }
        catch(error){
            console.log(error);
        }
    }
    updateCategory=async(categ:ICategory)=>{
        try{
           await  axios.put("https://localhost:5001/category",categ);
           runInAction(()=>{
            
            this.categoryRegistry.set(categ.categoryId,categ)
             this.selectedCategory=categ;
             this.editmode=false;
             
           })
        }
        catch(error){
            console.log(error);
        }
    }
    deleteCategory=async(id:number)=>{
        try{
           
           await axios.delete("https://localhost:5001/category");
           runInAction(()=>{
            //this.pacientat=[...this.pacientat.filter(a => a.pacient_Id !== id)]
            this.categoryRegistry.delete(id);
            ;if(this.selectedCategory!.categoryId==id)this.canceleSelectedCategory();

           })
        
        }
        catch(error){
            console.log(error);
        }
    }
   
}
