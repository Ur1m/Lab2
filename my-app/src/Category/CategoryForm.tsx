
import React ,{  FormEvent, useState}from 'react'
import * as yup from 'yup';
import {Formik} from 'formik';
import { observer } from 'mobx-react-lite';
import { on } from 'stream';
import { useStore } from '../store/Store';
import { ICategory } from './ICategory';
import {Form,Button, Segment} from 'semantic-ui-react';
import { FormControl, Input } from '@mui/material';


export default  observer( function CategoryForm ()  {
    const {CategoryStore}=useStore();
    const{closeForm,selectedCategory,updateCategory,createCategory,categories
    }=CategoryStore;
    var open=false;
   

   
    const initialState = selectedCategory ?? {
        categoryId:0,
        name: '',
        description: '',
        image:'',
        displayOrder:0,
        isDeleted:false,
       
    }
    const [Category,setCategory]=useState<ICategory>(initialState)
    const handleinputchange =(event:FormEvent<HTMLInputElement | HTMLTextAreaElement>)=>{
    
        setCategory({...Category,[event.currentTarget.name]:event.currentTarget.value});
    };
   
    const handleFormsubmit=(Category:ICategory)=>{
      if(Category.categoryId==0){
        
         createCategory(Category);
         open=false;
      
    }
    else{
        updateCategory(Category)
    }
       
    }
    
   
        
    
    
    const validationSchema=yup.object({
        name:yup.string().required("required").matches(/^[a-zA-Z0-9]{3,}$/,'Emri duhet te ket mbi 3 shkronja'),
        description:yup.string().required("required").matches(/^[a-zA-Z0-9]{3,}$/,'Mbimeri duhet te ket mbi 3 shkronja'),
        displayOrder:yup.string().required("required").nullable(),
        isDeleted:yup.string().required(''),
       
        


    })
   
    return (
        <Segment clearing>
          
        <Formik validationSchema={validationSchema}
      enableReinitialize initialValues={Category!} onSubmit={values => handleFormsubmit(values)}>
      {({handleSubmit,isSubmitting,dirty,isValid})=>(
          <Form className='ui form' onSubmit={handleSubmit}>
            <Input placeholder='Emri' name="name"/>
            <Input placeholder="Mbimeri" name="description"/>
           
            <Input placeholder='Specializimi' name='image'/>
            <Input  placeholder='Zgjedhni departamentin...' name=''/>
          <Button 
          disabled={isSubmitting || !dirty || !isValid}
          floated="right"  type='submit' content='submit'/>
          <Button onClick={closeForm}floated="right"  type='submit' content='cancel'/>
         
         
         
      </Form>
      


       )

       }
      </Formik>
     
     
      
  </Segment>
  

       

       
     
             
               
    )
               
});
          
            

            
            
       
    
