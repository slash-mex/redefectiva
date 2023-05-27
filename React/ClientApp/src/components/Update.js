import React, { Component, useState, useEffect } from 'react';

const App = () => {
    const [posts, setPosts] = useState([]);
    const [nombre, setNombre] = useState('');
    const [id, setId] = useState('');
    const [body, setBody] = useState('');

    const addPosts = async (id, nombre) => {
        await fetch('http://localhost:57678/Personas', {
            method: 'PUT',
            body: JSON.stringify({
                "id": id,
                "nombre": nombre
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
                'Access-Control-Allow-Origin': "*"
            },
        })
            .then((response) => response.json())
            .then((data) => {
                setPosts((posts) => [data, ...posts]);
                setBody('');
            })
            .catch((err) => {
                console.log(err.message);
            });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        addPosts(id, nombre);
        alert("Enviado!");
    };

    return (
        <div>
            <h1>Update</h1>

            <p>Aqui puedes modificar un registro existente de la tabla personas</p>
            <form onSubmit={handleSubmit}>
                Id: <input type="text" className="form-control" name="Id" value={id} onChange={(e) => setId(e.target.value)} />
                Nombre: <input type="text" className="form-control" name="Nombre" value={nombre} onChange={(e) => setNombre(e.target.value)} />
                <br />
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>

        </div>
    );
};

export default App;