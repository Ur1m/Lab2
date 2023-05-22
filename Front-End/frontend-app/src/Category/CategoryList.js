import react, { useEffect, useState, Fragment } from "react";
import axios from "axios";
import { Button, Modal, Header, Icon } from "semantic-ui-react";
import CategoryForm from "./CategoryForm";

//import {observer} from 'mobx-react-lite'

export default function CategoryList() {
  const categs = [{ categoryId: 1, name: "Berat", desctription: "diqka" }];
  const [categories, setCategories] = useState(categs);
  const [open, setOpen] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState(0);
  const [openform, setopenform] = useState(false);
  const [fullselectedCategory, setfullselectedCategory] = useState(undefined);

  //  const categs=[{categoryId:1,name:"Berat",desctription:"diqka"}]
  // setCategories(categs);
  //const[search,setsearch]=useState("");
  useEffect(() => {
    axios.get("https://localhost:44388/api/category").then((response) => {
      setCategories(response.data);
      console.log(response.data);
    });
    //console.log("data");
  }, []);

  function deletecateg(id) {
    setOpen(true);
    setSelectedCategory(id);
    console.log("deletecateg");
    console.log(open);
    console.log(open);
  }
  function openForm() {
    setopenform(true);
  }
  function closeForm() {
    setopenform(false);
  }
  function openeditForm(id) {
    setfullselectedCategory(categories.filter((a) => a.categoryId == id)[0]);
    console.log(fullselectedCategory);
    setopenform(true);
  }
  const finaldelete = () => {
    axios
      .delete(`https://localhost:44388/api/category/${selectedCategory}`)
      .then(
        setCategories([
          ...categories.filter((a) => a.categoryId !== selectedCategory),
        ])
      );
    setSelectedCategory(0);
    setOpen(false);
  };
  const handleCreatecategory = (Category) => {
    console.log(Category);
    axios
      .post("https://localhost:44388/api/category", Category)
      .then(() => setCategories(...categories, Category));
    closeForm();
  };
  const handleeditcategory = (Category) => {
    console.log(Category);
    axios
      .put("https://localhost:44388/api/category", Category)
      .then(() =>
        setCategories(
          ...categories.filter((a) => a.categoryId != Category.categoryId),
          Category
        )
      );
    closeForm();
  };

  return (
    <Fragment>
      <Button
        floated="right"
        content="add"
        color="blue"
        onClick={() => openForm()}
      />
      <div className="container">
        <table className="table table-hover">
          <thead className="table-dark">
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Name</th>
              <th scope="col">Description</th>
              <th scope="col">Edit</th>
              <th scope="col">Delete</th>
            </tr>
          </thead>
          <tbody>
            {categories.map((categ) => (
              <tr key={categ.categoryId} className="table-secondary">
                <th scope="row">{categ.categoryId}</th>
                <td>{categ.name}</td>
                <td>{categ.desctription}</td>
                <td>
                  <Button
                    color="blue"
                    content="edit"
                    onClick={() => openeditForm(categ.categoryId)}
                  />
                </td>
                <td>
                  <Button
                    onClick={() => deletecateg(categ.categoryId)}
                    color="red"
                    content="delete"
                  />
                </td>
              </tr>
            ))}
          </tbody>
          <Modal
            closeIcon
            open={open}
            //trigger={<Button>Show Modal</Button>}
            onClose={() => setOpen(false)}
            onOpen={() => setOpen(true)}
          >
            <Header icon="archive" content="Archive Old Messages" />
            <Modal.Content>
              <p>Do you want to delete category</p>
            </Modal.Content>
            <Modal.Actions>
              <Button color="red" onClick={() => setOpen(false)}>
                <Icon name="remove" /> No
              </Button>
              <Button color="green" onClick={() => finaldelete()}>
                <Icon name="checkmark" /> Yes
              </Button>
            </Modal.Actions>
          </Modal>
        </table>
        <Modal
          onClose={() => setopenform(false)}
          onOpen={() => setopenform(true)}
          open={openform}
          // trigger={<Button>Show Modal</Button>}
        >
          <Modal.Description>
            <CategoryForm
              selectedCategory={fullselectedCategory}
              handleCreatecategory={handleCreatecategory}
              handleeditcategory={handleeditcategory}
              closeform={closeForm}
            />
          </Modal.Description>
        </Modal>
      </div>
    </Fragment>
  );
}
