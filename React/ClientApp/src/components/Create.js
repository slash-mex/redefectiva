//import React, { Component, useState, useEffect } from 'react';

//export class Create extends Component {
//    static displayName = Create.name;
    

//    constructor(props) {
//        super(props);
//        this.state = { currentCount: 0 };

//    }

//    handleSubmit(e){
//        e.preventDefault();
//        alert(this.nombre);
//    };

//    render() {
//        return (
//            <div>
//                <h1>Create</h1>

//                <p>Aqui puedes agregar un registro nuevo a la tabla personas</p>

//                <form onSubmit={this.handleSubmit}>
//                    Nombre: <input type="text" className="form-control" name="Nombre" value={this.nombre} />
//                    Apellido Paterno: <input type="text" className="form-control" name="ApellidoPaterno" />
//                    Apellido Materno: <input type="text" className="form-control" name="ApellidoMaterno" />
//                    Edad: <input type="text" className="form-control" name="Edad" />
//                    Peso: <input type="text" className="form-control" name="Peso" />
//                    <br />
//                    <button type="submit" className="btn btn-primary">Submit</button>
//                </form>

//            </div>
//        );
//    }
//}
import React, { Component, useState, useEffect } from 'react';

const App = () => {
    const [posts, setPosts] = useState([]);
    const [nombre, setNombre] = useState('');
    const [apellidoPaterno, setApellidoPaterno] = useState('');
    const [apellidoMaterno, setApellidoMaterno] = useState('');
    const [edad, setEdad] = useState('');
    const [estatura, setEstatura] = useState('');
    const [body, setBody] = useState('');

    const addPosts = async (nombre, apellidoPaterno, apellidoMaterno, edad, estatura) => {
        await fetch('http://localhost:57678/Personas', {
            method: 'POST',
            body: JSON.stringify({
                "nombre": nombre,
                "apellidoPaterno": apellidoPaterno,
                "apellidoMaterno": apellidoMaterno,
                "edad": edad,
                "estatura": estatura
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
        addPosts(nombre, apellidoPaterno, apellidoMaterno, edad, estatura);
        alert("Enviado!");
    };

    return (
        <div>
            <h1>Create</h1>

            <p>Aqui puedes agregar un registro nuevo a la tabla personas</p>
            <form onSubmit={handleSubmit}>
                Nombre: <input type="text" className="form-control" name="Nombre" value={nombre} onChange={(e) => setNombre(e.target.value)} />
                Apellido Paterno: <input type="text" className="form-control" name="ApellidoPaterno" value={apellidoPaterno} onChange={(e) => setApellidoPaterno(e.target.value)} />
                Apellido Materno: <input type="text" className="form-control" name="ApellidoMaterno" value={apellidoMaterno} onChange={(e) => setApellidoMaterno(e.target.value)} />
                Edad: <input type="text" className="form-control" name="Edad" value={edad} onChange={(e) => setEdad(e.target.value)} />
                Estatura: <input type="text" className="form-control" name="Estatura" value={estatura} onChange={(e) => setEstatura(e.target.value)} />
                <br />
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>

        </div>
    );
};

export default App;