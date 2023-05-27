# redefectiva
El proyecto se divide en 2 partes:
- React
- API

La carpeta React contiene el código del website que consume el API, está hecho en .Net y React. Al iniciar el servicio, habra 4 opciones en el menu: Delete, Update, Create y Display. Cada uno corresponde a uno de los métodos CRUD.

La carpeta API contiene el proyecto del API Rest elaborado con el template de https://github.com/ardalis/cleanarchitecture. Este de debe ejecutar desde visual Studio o hacer un despliegue en IIS. Tiene una dependencia con SQLite, que es donde se almacen a la información. La base de datos ya se encuentra incluida en el proyecto en API.Web/database.sqlite
