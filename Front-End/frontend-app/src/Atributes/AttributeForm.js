import React, { useState, useEffect } from "react";
import MyTextInput from "../FormElements/MyTextArea";
import MyTextArea from "../FormElements/MyTextInput";
import axios from "axios";
import * as yup from "yup";
import MySelectInput from "../FormElements/MySelectInput";
import { Button, Fragment, Segment, Form } from "semantic-ui-react";
import { Formik } from "formik";
import { runInAction } from "mobx";

import { useStore } from "../Store/Store";
export const AttributesForm = () => {
  const { AttributeStore } = useStore();
  const {
    selectedAttribute,
    closeForm,
    updateAttribute,
    createAttribute,
    attributevalues,
    addAttributevalue,
    deleteAttribute,
    attributes,
  } = AttributeStore;

  /* useEffect(()=> {
         axios.get("https://localhost:44388/api/category").then((response) => 
           response.data 
        ).then((categ)=>setCategories(...categories,{text:categ.name,key:categ.categoryId,value:categ.categoryId}));
       // console.log(categoriess.);
        
        //console.log("data");
        
    },[]);
*/

  const initialState = selectedAttribute ?? {
    attributeId: 0,
    name: "",
    values: "",
  };
  const atrvalue = {
    attributeId: 0,
    value: "",
  };
  const [attribute, setAttribute] = useState(initialState);

  const handleinputchange = (event) => {
    setAttribute({
      ...attribute,
      [event.currentTarget.name]: event.currentTarget.value,
    });
  };

  const handleFormsubmit = (attr) => {
    console.log(attr);
    if (attr.attributeId == 0) {
      createAttribute(attr);
      var atrs = attr.values.split(",");
      var lastid = 0;
      attributes.forEach((x) => (lastid = x.attributeId));
      console.log(lastid);

      atrs.forEach((element) => {
        atrvalue.attributeId = lastid + 1;
        atrvalue.value = element;
        addAttributevalue(atrvalue);
      });
    } else {
      deleteAttribute(attr.attributeId);
      createAttribute(attr);
      var atrs = attr.values.split(",");
      atrs.forEach((element) => {
        atrvalue.attributeId = 2;
        atrvalue.value = element;
        addAttributevalue(atrvalue);
      });
    }
  };
  const validationSchema = yup.object({
    name: yup
      .string()
      .matches(
        /^[a-zA-Z0-9]{3,}$/,
        "Name should contain more than 3 characters."
      )
      .required("Please type a name."),
    values: yup.string().required(),

    // dataRegjistrimit:yup.string().required("Selektoni daten e servisimimit te fundit"),

    // image:yup.string().required("Selektoni foton")
  });

  return (
    <Segment clearing>
      <Formik
        validationSchema={validationSchema}
        enableReinitialize
        initialValues={attribute}
        onSubmit={(values) => handleFormsubmit(values)}
      >
        {({ handleSubmit, isSubmitting, dirty, isValid }) => (
          <Form className="ui form" onSubmit={handleSubmit}>
            <MyTextInput name="name" placeholder="Name" />
            <MyTextInput name="values" placeholder="Values" />

            <Button
              disabled={isSubmitting || !dirty || !isValid}
              floated="right"
              positive
              type="subimit"
              content="submit"
            />
            <Button
              onClick={closeForm}
              floated="right"
              type="subimit"
              content="cancel"
            />
          </Form>
        )}
      </Formik>
    </Segment>
  );
};
