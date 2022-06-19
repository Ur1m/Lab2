import axios from "axios";
import { makeAutoObservable, runInAction } from "mobx";


export default class AttributeStore{
    
    selectedAttribute=undefined;
    editmode=false;
    
    detailsmode=false;
    attributesRegistry=new Map();
    attributeValuesRegistry=new Map();
    constructor(){
        makeAutoObservable(this)
    }
    loadAttributes= async ()=>{
       try{
        const  attr=await (await axios.get("https://localhost:44388/api/attribute")).data;
        console.log(attr);
        runInAction(()=>{
            
            attr.forEach((atr) =>{
              
                this.attributesRegistry.set(atr.attributeId,atr);
                
            })
        
        
        })
       }
       catch(error){
           console.log(error);
       }
    }
    loadAttributesValues= async ()=>{
        try{
         const  attrvalues=await (await axios.get("https://localhost:44388/api/attribute/attributevalues")).data;
         console.log(attrvalues);
         
         runInAction(()=>{
             
             attrvalues.forEach((atr) =>{
               
                 
                      this.attributeValuesRegistry.set(atr.attributevalueId,atr);
                        
             })
         })
         
        
        }
        catch(error){
            console.log(error);
        }
     }
   
    get attributes(){
        return Array.from(this.attributesRegistry.values());
    }
    get attributevalues(){
        return Array.from(this.attributeValuesRegistry.values());
    }
    openDetails=(id)=>{
        this.selectAttribute(id);
        this.detailsmode=true;
    }
    closeDetails=()=>{
        this.detailsmode=false;
    }
    selectAttribute=(id)=>{
      this.selectedAttribute=this.attributesRegistry.get(id);
    }
    canceleSelectedAtttribute=()=>{
        this.selectedAttribute=undefined;
    }
   
    openForm=(id)=>{
        id? this.selectAttribute(id) : this.canceleSelectedAtttribute();
        this.editmode=(true);
    }
    closeForm=()=>{
        this.editmode=false;
    }
    createAttribute=async(attr)=>{
        
        try{
            await axios.post("https://localhost:44388/api/attribute",attr);
            runInAction(()=>{
                this.attributesRegistry.set(attr.attributeId,attr);
                this.selectedProduct=attr;
                this.editmode=false;
               
            })
        }
        catch(error){
            console.log(error);
        }
    }
    addAttributevalue=async(attrvalue)=>{
        try{
            await axios.post("https://localhost:44388/api/attribute/addvalue",attrvalue);
            runInAction(()=>{
                this.attributeValuesRegistry.set(attrvalue.attributevalueId,attrvalue);
               
               
               
            })
        }
        catch(error)
        {
           console.log(error);
        }
    }
    updateAttribute=async(attr)=>{
        try{
           await  axios.put("https://localhost:44388/api/attribute",attr);
           runInAction(()=>{
            
            this.attributesRegistry.set(attr.attributeId,attr)
             this.selectedProduct=attr;
             this.editmode=false;
             
           })
        }
        catch(error){
            console.log(error);
        }
    }
    deleteAttribute=async(id)=>{
        try{
           
           await axios.delete(`https://localhost:44388/api/attribute/${id}`);
           runInAction(()=>{
           
            this.attributesRegistry.delete(id);
            ;if(this.selectedAttribute.attributeId==id)this.canceleSelectedProduct();

           })
        
        }
        catch(error){
            console.log(error);
        }
    }
    deleteAttributeValue=async(id)=>{
        try{
           
           await axios.delete(`https://localhost:44388/api/attribute/atrvalue/${id}`);
           runInAction(()=>{
            
            this.attributeValuesRegistry.delete(id);
           

           })
        
        }
        catch(error){
            console.log(error);
        }
    }
   
}
