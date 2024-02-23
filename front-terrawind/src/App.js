import React, { useState, useEffect } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

const baseUrl = "https://localhost:44339/api/gestores";

function App() {
  const [data, setData] = useState([]);
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalEliminar, setModalEliminar] = useState(false);
  const [gestorSeleccionado, setGestorSeleccionado] = useState({
    id: '',
    nombre: '',
    lanzamiento: '',
    desarrollador: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    // Actualiza el estado de gestorSeleccionado manteniendo el contenido anterior y actualizando el campo modificado
    setGestorSeleccionado((prevGestor) => ({
      ...prevGestor,
      [name]: value,
    }));
  };

  const toggleModalInsertar = () => setModalInsertar(!modalInsertar);
  const toggleModalEditar = () => setModalEditar(!modalEditar);
  const toggleModalEliminar = () => setModalEliminar(!modalEliminar);

  // Manejo de la solicitud POST para agregar un nuevo gestor
  const handlePostRequest = async () => {
    try {
      const response = await axios.post(baseUrl, gestorSeleccionado);
      // Actualiza el estado de data agregando el nuevo gestor
      setData((prevData) => [...prevData, response.data]);
      toggleModalInsertar();
    } catch (error) {
      console.error(error);
    }
  };

  // Manejo de la solicitud PUT para editar un gestor existente
  const handlePutRequest = async () => {
    try {
      await axios.put(`${baseUrl}/${gestorSeleccionado.id}`, gestorSeleccionado);
      // Actualiza el estado de data reemplazando el gestor editado
      setData((prevData) =>
        prevData.map((gestor) =>
          gestor.id === gestorSeleccionado.id ? { ...gestorSeleccionado } : gestor
        )
      );
      toggleModalEditar();
    } catch (error) {
      console.error(error);
    }
  };

  // Manejo de la solicitud DELETE para eliminar un gestor
  const handleDeleteRequest = async () => {
    try {
      await axios.delete(`${baseUrl}/${gestorSeleccionado.id}`);
      // Actualiza el estado de data filtrando el gestor eliminado
      setData((prevData) => prevData.filter((gestor) => gestor.id !== gestorSeleccionado.id));
      toggleModalEliminar();
    } catch (error) {
      console.error(error);
    }
  };

  // Función para seleccionar un gestor y abrir el modal correspondiente
  const selectGestor = (gestor, action) => {
    setGestorSeleccionado(gestor);
    action === "Editar" && toggleModalEditar();
    action === "Eliminar" && toggleModalEliminar();
  };

  // Función para abrir el modal de edición y actualizar los datos del gestor seleccionado
  const handleModalEditarOpen = () => {
    setGestorSeleccionado((prevGestor) => ({ ...prevGestor, ...data.find((g) => g.id === prevGestor.id) }));
    toggleModalEditar();
  };

  // useEffect para cargar los datos iniciales al renderizar el componente
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(baseUrl);
        // Actualiza el estado de data con los datos obtenidos de la API
        setData(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);

  return (
    <div className="App">
      <br />
      {/* Botón para abrir el modal de inserción */}
      <button onClick={toggleModalInsertar} className='btn btn-success'>Insertar nuevo registro</button>
      <br /><br />
      {/* Tabla para mostrar los gestores */}
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Lanzamiento</th>
            <th>Desarrollador</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {/* Mapeo de los datos para renderizar las filas de la tabla */}
          {data.map((gestor) => (
            <tr key={gestor.id}>
              <td>{gestor.id}</td>
              <td>{gestor.nombre}</td>
              <td>{gestor.lanzamiento}</td>
              <td>{gestor.desarrollador}</td>
              <td>
                {/* Botones para editar y eliminar un gestor */}
                <button className="btn btn-primary" onClick={() => selectGestor(gestor, "Editar")}>Editar</button>{" "}
                <button className="btn btn-danger" onClick={() => selectGestor(gestor, "Eliminar")}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Modal para insertar un nuevo gestor */}
      <Modal isOpen={modalInsertar}>
        <ModalHeader>Insertar Registro</ModalHeader>
        <ModalBody>
          <div className="form-group">
            {/* Campos de entrada para insertar un nuevo gestor */}
          </div>
        </ModalBody>
        <ModalFooter>
          {/* Botones para confirmar o cancelar la inserción */}
          <button className="btn btn-primary" onClick={handlePostRequest}>Insertar</button>{" "}
          <button className="btn btn-danger" onClick={toggleModalInsertar}>Cancelar</button>
        </ModalFooter>
      </Modal>

      {/* Modal para editar un gestor */}
      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Registro</ModalHeader>
        <ModalBody>
          <div className="form-group">
            {/* Campos de entrada para editar un gestor */}
          </div>
        </ModalBody>
        <ModalFooter>
          {/* Botones para confirmar o cancelar la edición */}
          <button className="btn btn-primary" onClick={handlePutRequest}>Editar</button>{" "}
          <button className="btn btn-danger" onClick={toggleModalEditar}>Cancelar</button>
        </ModalFooter>
      </Modal>

      {/* Modal para confirmar la eliminación de un gestor */}
      <Modal isOpen={modalEliminar}>
        <ModalBody>
          <div>
            {/* Mensaje de confirmación de eliminación */}
            <h3>{`¿Estás seguro que deseas eliminar el registro ${gestorSeleccionado.id}?`}</h3>
          </div>
        </ModalBody>
        <ModalFooter>
          {/* Botones para confirmar o cancelar la eliminación */}
          
          <button className="btn btn-danger" onClick={handleDeleteRequest}>Sí</button>{" "}
          <button className="btn btn-secondary" onClick={toggleModalEliminar}>No</button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default App;
