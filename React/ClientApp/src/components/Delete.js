import React, { Component, useState, useEffect } from 'react';

const App = () => {
    const [posts, setPosts] = useState([]);
    const [Id, setId] = useState('');
    const [body, setBody] = useState('');

    const deleteId = async (Id) => {
        await fetch('http://localhost:57678/Personas/'+Id, {
            method: 'DELETE',
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
        deleteId(Id);
        alert("Enviado!");
    };

    return (
        <div>
            <h1>Delete</h1>

            <p>Aqui puedes borrar una persona</p>
            <form onSubmit={handleSubmit}>
                Id: <input type="text" className="form-control" name="Id" value={Id} onChange={(e) => setId(e.target.value)} />
                <br />
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>

        </div>
    );
};

export default App;