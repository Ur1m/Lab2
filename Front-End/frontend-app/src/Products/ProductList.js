import React, { useEffect, Fragment } from "react";
import { observer } from "mobx-react-lite";
import { useStore } from "../Store/Store";
import { Button, Modal, Header, Icon } from "semantic-ui-react";
import { ProductsForm } from "./ProductsForm";

export default observer(function ProductList() {
  const { ProductStore } = useStore();
  const {
    selectedProduct,
    openForm,
    products,
    editmode,
    selectProduct,
    deleteProduct,
  } = ProductStore;
  const [open, setOpen] = React.useState(false);

  useEffect(() => {
    ProductStore.loadProducts();
  }, [ProductStore]);

  //  const categs=[{categoryId:1,name:"Berat",desctription:"diqka"}]
  // setCategories(categs);
  //const[search,setsearch]=useState("");

  function del(id) {
    selectProduct(id);
    setOpen(true);
  }

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
              <th scope="col">Price</th>
              <th scope="col">CategoryId</th>
              <th scope="col">edit</th>
              <th scope="col">delete</th>
            </tr>
          </thead>
          <tbody>
            {products.map((prod) => (
              <tr key={prod.id} className="table-secondary">
                <th scope="row">{prod.id}</th>
                <td>{prod.name}</td>
                <td>{prod.desctription}</td>
                <td>{prod.price}</td>
                <td>{prod.categoryId}</td>
                <td>
                  <Button
                    color="blue"
                    content="edit"
                    onClick={() => openForm(prod.id)}
                  />
                </td>
                <td>
                  <Button
                    color="red"
                    content="delete"
                    onClick={() => del(prod.id)}
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
              <p>Product</p>
            </Modal.Content>
            <Modal.Actions>
              <Button color="red" onClick={() => setOpen(false)}>
                <Icon name="remove" /> No
              </Button>
              <Button
                color="green"
                onClick={() => deleteProduct(selectedProduct.id)}
              >
                <Icon name="checkmark" /> Yes
              </Button>
            </Modal.Actions>
          </Modal>
        </table>
        <Modal
          onClose={() => openForm(false)}
          onOpen={() => openForm(true)}
          open={editmode}
          // trigger={<Button>Show Modal</Button>}
        >
          <Modal.Description>
            <ProductsForm />
          </Modal.Description>
        </Modal>
      </div>
    </Fragment>
  );
});
