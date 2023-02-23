import React, { useState,useEffect } from "react";
import MyTextInput from "../FormElements/MyTextArea";
import MyTextArea from "../FormElements/MyTextInput";
import axios from 'axios';
import * as yup from 'yup';
import MySelectInput from "../FormElements/MySelectInput";
import { Button,Fragment,Segment,Form } from "semantic-ui-react";
import { Formik } from "formik";
import {runInAction} from 'mobx';

import { useStore } from "../Store/Store";
export const ProductsForm = () => {
    const {ProductStore}=useStore();
    const{selectedProduct,closeForm,updateProduct,createProduct}=ProductStore;
    const {categories,setCategories}=useState({text:"test",key:'5',value:'5'});

   /* useEffect(()=> {
         axios.get("https://localhost:44388/api/category").then((response) => 
           response.data 
        ).then((categ)=>setCategories(...categories,{text:categ.name,key:categ.categoryId,value:categ.categoryId}));
       // console.log(categoriess.);
        
        //console.log("data");
        
    },[]);
*/
   
    const initialState = selectedProduct ?? {
        id: 0,
        name: '',
        desctription: '',
        categoryId: 0,
        image:'',
        price:0,

    }
    const [Product,setProduct]=useState(initialState)
    const [image,setimage]=useState();
    const handleinputchange =(event)=>{
    
        setProduct({...Product,[event.currentTarget.name]:event.currentTarget.value});
    };
    const changefile=(event)=>{
     
        let v=event.target.files;
        let reader=new FileReader();
     reader.readAsDataURL(v[0]);
        reader.onload=(e)=>{
         setimage( e.target?.result);
        }
     }
    const handleFormsubmit=(product)=>{
       if(image!=null)
       {
        product.image=image;
       }
      
      if(product.id==0){
        createProduct(product);
        
      }
    else{
        updateProduct(product);
    }

       
      
    }
    const validationSchema=yup.object({
        name:yup.string().matches(/^[a-zA-Z0-9]{3,}$/,'Passwordi duhet te ket mbi 3 shkronja').required("Ju lutem shenoni emrin e paisjes"),
        desctription:yup.string().required("Pershkrimi nuk duhet te jete i zbrazet").matches(/^[a-zA-Z0-9 -?]{15,}$/,'Pershkrimi nuk duhet me qene ner 15 karaktere'),
        categoryId:yup.string().required(),
        price :yup.number().required(),


     // dataRegjistrimit:yup.string().required("Selektoni daten e servisimimit te fundit"),
      
      // image:yup.string().required("Selektoni foton")
      


    })

   
  
    return (
        <Segment clearing>
     <Formik validationSchema={validationSchema}
            enableReinitialize 
            initialValues={Product} onSubmit={values => handleFormsubmit(values)}>
            {({handleSubmit,isSubmitting,dirty,isValid})=>(
                <Form className='ui form' onSubmit={handleSubmit}>
                   <MyTextInput name='name' placeholder='Emri..'/>
                <MyTextInput type="number" name="price" placeholder="Price"/>
                <MyTextArea rows={3} placeholder="pershkrimi"name="desctription"/>
                <MyTextInput type="number" placeholder='Category' name='categoryId'/>
              
                 <input type='file' name='image' placeholder="image" onChange={changefile} />

                
                <Button 
                disabled={ !isValid}
                floated="right" positive type='subimit' content='submit'/>
                <Button onClick={closeForm}floated="right"  type='subimit' content='cancel'/>
            </Form>


             )

             }
            </Formik>


          
           
            
        </Segment>
    );
}
