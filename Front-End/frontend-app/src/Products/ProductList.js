import React, { useEffect, Fragment, useState } from "react";
import { observer } from "mobx-react-lite";
import { useStore } from "../Store/Store";
import { Button, Modal, Header, Icon, Table } from "semantic-ui-react";
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
    loadProducts,
  } = ProductStore;

  useEffect(() => {
    loadProducts();
  }, [loadProducts]);

  const [deleteConfirmationOpen, setDeleteConfirmationOpen] = useState(false);

  const handleDelete = (id) => {
    selectProduct(id);
    setDeleteConfirmationOpen(true);
  };

  return (
    <Fragment>
      <Button
        floated="right"
        content="+"
        color="blue"
        onClick={openForm}
      />
      <div className="container">
        <Table celled>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell>Name</Table.HeaderCell>
              <Table.HeaderCell>Description</Table.HeaderCell>
              <Table.HeaderCell>Price</Table.HeaderCell>
              <Table.HeaderCell>Edit</Table.HeaderCell>
              <Table.HeaderCell>Delete</Table.HeaderCell>
            </Table.Row>
          </Table.Header>
          <Table.Body>
            {products.map((prod) => (
              <Table.Row key={prod.id}>
                <Table.Cell>{prod.name}</Table.Cell>
                <Table.Cell>{prod.desctription}</Table.Cell>
                <Table.Cell>{prod.price}</Table.Cell>
                <Table.Cell>
                  <Button
                    color="blue"
                    content="Edit"
                    onClick={() => openForm(prod.id)}
                  />
                </Table.Cell>
                <Table.Cell>
                  <Button
                    color="red"
                    content="Delete"
                    onClick={() => handleDelete(prod.id)}
                  />
                </Table.Cell>
              </Table.Row>
            ))}
          </Table.Body>
        </Table>

        <Modal
          closeIcon
          open={deleteConfirmationOpen}
          onClose={() => setDeleteConfirmationOpen(false)}
          size="mini"
        >
          <Header icon="archive" content="Confirm Delete" />
          <Modal.Content>
            <p>Are you sure you want to delete this product?</p>
          </Modal.Content>
          <Modal.Actions>
            <Button color="red" onClick={() => setDeleteConfirmationOpen(false)}>
              <Icon name="remove" /> No
            </Button>
            <Button
              color="green"
              onClick={() => {
                deleteProduct(selectedProduct.id);
                setDeleteConfirmationOpen(false);
              }}
            >
              <Icon name="checkmark" /> Yes
            </Button>
          </Modal.Actions>
        </Modal>

        <Modal
          open={editmode}
          onClose={() => openForm(false)}
          size="small"
        >
          <Modal.Description>
            <ProductsForm />
          </Modal.Description>
        </Modal>
      </div>
    </Fragment>
  );
});
