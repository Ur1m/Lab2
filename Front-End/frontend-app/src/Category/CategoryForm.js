import { Segment, Form, Button } from "semantic-ui-react";
import * as yup from "yup";
import { Formik } from "formik";
import { useState } from "react";
import MyTextInput from "../FormElements/MyTextArea";
import MyTextArea from "../FormElements/MyTextInput";

export default function CategoryForm({
  handleCreatecategory,
  handleeditcategory,
  closeform,
  selectedCategory,
}) {
  const initialState = selectedCategory ?? {
    categoryId: 0,
    name: "",
    desctription: "",
  };
  const [categ, setCateg] = useState(initialState);
  const handleinputchange = (event) => {
    setCateg({
      ...categ,
      [event.currentTarget.name]: event.currentTarget.value,
    });
  };

  const handleFormsubmit = (Category) => {
    if (selectedCategory == undefined) {
      console.log("create");
      handleCreatecategory(Category);
    } else {
      console.log("edit");
      handleeditcategory(Category);
    }
  };

  const validationSchema = yup.object({
    name: yup
      .string()
      .required("You must enter a name.")
      .matches(
        /^[a-zA-Z0-9]{3,}$/,
        "Name should contain more than 3 characters."
      ),
    desctription: yup
      .string()
      .required("You must enter a description.")
      .matches(
        /^[a-zA-Z0-9]{15,}$/,
        "Description should contain more than 3 characters."
      ),
  });

  return (
    <Segment clearing>
      <Formik
        validationSchema={validationSchema}
        enableReinitialize
        initialValues={categ}
        onSubmit={(values) => handleFormsubmit(values)}
      >
        {({ handleSubmit, isSubmitting, dirty, isValid }) => (
          <Form className="ui form" onSubmit={handleSubmit}>
            <input name="categoryId" type="hidden" />
            <MyTextInput type="text" name="name" placeholder="Name" />
            <MyTextArea
              rows={2}
              name="desctription"
              placeholder="description"
            />

            <Button
              disabled={isSubmitting || !dirty || !isValid}
              floated="right"
              positive
              type="submit"
              content="submit"
            />
            <Button
              floated="right"
              type="submit"
              content="cancel"
              onClick={() => closeform()}
            />
          </Form>
        )}
      </Formik>
    </Segment>
  );
}
