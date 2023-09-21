import React, { useState, useEffect } from "react";
import axios from "axios";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

export const Test = () => {
  const [prod, setProd] = useState([]);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [playerData, setPlayerData] = useState({
    Name: "",
    BirthDay: "",
    TeamId: "",
  });

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handleShowModal = () => {
    setShowModal(true);
  };

  const handleChange = (event) => {
    const { name, value } = event.target;
    setPlayerData({
      ...playerData,
      [name]: value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    axios
      .post("https://localhost:5002/addPlayer", playerData)
      .then((response) => {
        // Handle success, maybe update the state or show a success message
        // You can also close the modal here if needed
        handleCloseModal();
      })
      .catch((error) => {
        setError(error);
      });
  };

  useEffect(() => {
    axios
      .get("https://localhost:5002/api/Team/getTeams")
      .then((response) => {
        setProd(response.data);
      })
      .catch((error) => {
        setError(error);
      });
  }, []);

  return (
    <div className="container">
      <Button variant="primary" onClick={handleShowModal}>
        Add Player
      </Button>
      <table className="table table-hover">
        <thead className="table-dark">
          <tr>
            <th scope="col">Name</th>
          </tr>
        </thead>
        <tbody>
          {prod.map((team) => (
            <tr key={team.name} className="table-secondary">
              <th scope="row">Secondary</th>
              <td>{team.name}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Add Player</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="name">
              <Form.Label>Name</Form.Label>
              <Form.Control
                type="text"
                name="Name"
                value={playerData.Name}
                onChange={handleChange}
                required
              />
            </Form.Group>
            <Form.Group controlId="birthDay">
              <Form.Label>BirthDay</Form.Label>
              <Form.Control
                type="date"
                name="BirthDay"
                value={playerData.BirthDay}
                onChange={handleChange}
                required
              />
            </Form.Group>
            <Form.Group controlId="teamId">
              <Form.Label>Team Id</Form.Label>
              <Form.Control
                type="text"
                name="TeamId"
                value={playerData.TeamId}
                onChange={handleChange}
                required
              />
            </Form.Group>
            <Button variant="primary" type="submit">
              Submit
            </Button>
          </Form>
        </Modal.Body>
      </Modal>
    </div>
  );
};
