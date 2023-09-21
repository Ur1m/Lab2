import React, { useState, useEffect } from "react";
import axios from "axios";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

export const Test = () => {
  const [teams, setTeams] = useState([]);
  const [players, setPlayers] = useState([]);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [showTeamModal, setShowTeamModal] = useState(false);
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
  const [teamData, setTeamData] = useState({
    Name: "",
  });
  const handleChange = (event) => {
    const { name, value } = event.target;
    setPlayerData({
      ...playerData,
      [name]: value,
    });
  };
  const handleCloseTeamModal = () => {
    setShowTeamModal(false);
  };
  const handleTeamChange = (event) => {
    const { name, value } = event.target;
    setTeamData({
      ...teamData,
      [name]: value,
    });
  };

  const handleShowTeamModal = () => {
    setShowTeamModal(true);
  };
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log("team data", teamData);
    axios
      .post("https://localhost:5002/addPlayer", null, {
        headers: {
          Name: playerData.Name,
          BirthDay: playerData.BirthDay,
          TeamId: playerData.TeamId,
        },
      })
      .then((response) => {
        // Handle success, maybe update the state or show a success message
        // You can also close the modal here if needed
        handleCloseModal();
      })
      .catch((error) => {
        setError(error);
      });
  };

  const handleTeamSubmit = (event) => {
    event.preventDefault();
    console.log("team data", teamData);
    axios
      .post("https://localhost:5002/addTeam?Name=" + teamData.Name)
      .then((response) => {
        // Handle success
        handleCloseTeamModal();
      })
      .catch((error) => {
        setError(error);
      });
  };

  useEffect(() => {
    // Fetch teams data
    axios
      .get("https://localhost:5002/getTeams")
      .then((response) => {
        setTeams(response.data);
      })
      .catch((error) => {
        setError(error);
      });

    // Fetch players data
    axios
      .get("https://localhost:5002/getPlayers")
      .then((response) => {
        setPlayers(response.data);
      })
      .catch((error) => {
        setError(error);
      });
  }, []);

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  return (
    <div className="container">
      <Button variant="primary" onClick={handleShowModal}>
        Add Player
      </Button>
      <Button variant="primary" onClick={handleShowTeamModal}>
        Add Team
      </Button>
      <table className="table table-hover">
        <thead className="table-dark">
          <tr>
            <th scope="col">Name</th>
          </tr>
        </thead>
        <tbody>
          {teams.map((team) => (
            <tr key={team.name} className="table-secondary">
              <td>{team.Id}</td>
              <td>{team.name}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <table className="table table-hover">
        <thead className="table-dark">
          <tr>
            <th scope="col">Player Name</th>
            <th scope="col">BirthDay</th>
            <th scope="col">TeamId</th>
          </tr>
        </thead>
        <tbody>
          {players.map((player, index) => (
            <tr key={index}>
              <td>{player.name}</td>
              <td>{player.birthDay}</td>
              <td>{player.teamId}</td>
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
            <Form.Group controlId="playerName">
              <Form.Label>Name</Form.Label>
              <Form.Control
                type="text"
                name="Name"
                value={playerData.Name}
                onChange={handleChange}
                required
              />
            </Form.Group>
            <Form.Group controlId="playerBirthDay">
              <Form.Label>BirthDay</Form.Label>
              <Form.Control
                type="date"
                name="BirthDay"
                value={playerData.BirthDay}
                onChange={handleChange}
                required
              />
            </Form.Group>
            <Form.Group controlId="playerTeam">
              <Form.Label>Team</Form.Label>
              <Form.Control
                as="select"
                name="TeamId"
                value={playerData.TeamId}
                onChange={handleChange}
                required
              >
                <option value="">Select a Team</option>
                {teams.map((team) => (
                  <option key={team.id} value={team.id}>
                    {team.name}
                  </option>
                ))}
              </Form.Control>
            </Form.Group>
            <Button variant="primary" type="submit">
              Submit
            </Button>
          </Form>
        </Modal.Body>
      </Modal>

      <Modal show={showTeamModal} onHide={handleCloseTeamModal}>
        <Modal.Header closeButton>
          <Modal.Title>Add Team</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handleTeamSubmit}>
            <Form.Group controlId="teamName">
              <Form.Label>Name</Form.Label>
              <Form.Control
                type="text"
                name="Name"
                value={teamData.Name}
                onChange={handleTeamChange}
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
