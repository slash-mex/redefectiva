import React, { Component, useState, useEffect } from 'react';

const App = () => {
    const [posts, setPosts] = useState([]);
    const [nombre, setNombre] = useState('');
    const [apellidoPaterno, setApellidoPaterno] = useState('');
    const [apellidoMaterno, setApellidoMaterno] = useState('');
    const [edad, setEdad] = useState('');
    const [estatura, setEstatura] = useState('');
    const [body, setBody] = useState('');

    useEffect(() => {
        fetch('http://localhost:57678/Personas')
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                setPosts(data);
            })
            .catch((err) => {
                console.log(err.message);
            });
    }, []);

    return (
        
        <div className="posts-container">
            <h1>Display</h1>

            <p>Aqui puedes ver las personas guardadas en la base de datos</p>
            {posts.map((post) => {
                return (
                    <p>{post.id} {post.nombre}</p>
                );
            })}
        </div>
    );
};

export default App;