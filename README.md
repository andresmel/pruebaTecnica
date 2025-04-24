# Sales Date Prediction

Sales Date Prediction es una aplicación web que permite crear órdenes y predecir la fecha de la próxima orden de cada cliente, utilizando el historial de registros almacenados en una base de datos.

Este proyecto está compuesto por:
**Frontend (Angular 18.2.12)** – ubicado en la carpeta webApp
**Backend (.NET 6 Web API)** – ubicado en la carpeta webApi

---

# Tecnologías utilizadas

- [Angular 18.2.12](https://angular.io/)
- [Node.js 20.x](https://nodejs.org/) *(recomendado para Angular 18)*
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

---

# Estructura del proyecto
 pruebaTecnica/
     |__webApp/
     |    |__public
     |    |    |__api
     |     |        |__apiRest
     |     |__src/
     |        |__app/
     |            |__core/
     |            |    |__Services/
     |            |__Features/
     |            |    |__Components
     |            |    |__Layouts
     |            |    |__Shared
     |            |__Shared/ 
     |                 |__Header
     |                 |__Loader
     |
     | __webApi
           |__controllers
           |__models
           |__repositories
           |     |__Irepositories
           |__services
           |     |__Iservices
           |__storeSampleContext
           |__Queries
           |__programs

 # Clonar el repositorio

bash
git clone https://github.com/andresmel/pruebaT-cnica.git
cd pruebaT-cnica

# ejecutar el backend
  cd webApi
  dotnet restore
  dotnet build
  dotnet run
  se ejecuta con el puerto https://localhost:7196;http://localhost:5160
  Debe cambiar la coneccion a la base de datos en el appsettings.json por sus credenciales de sql server local.

# Ejecutar el Fronend
cd ../webApp
npm install
ng serve
se ejecuta con el puerto http://localhost:4200


No se requiere autenticación para acceder a la aplicación.

# ejecucion del proyecto Sales Date Prediction
# backend
se desarrollo la api en .net 6 utilizando scaffold para crear el  Dbcontext y mapeo de entidades de la base de datos, se creó la carpeta controllers, los controller por cada entidad. una carpeta de repositorios para transacciones con la base de datos, lacarpeta servicios para la logica de la aplicacion. separe los servicios y repositorios por medio de interfaces. para separa responsabilidades y que sea mas facil el test. servicios y repositorios tienen sus carpetas de interfaces. en las respuestas de los controladores se creó un dto responseApi. cuenta con los atributos  status, data y message para capturar esta respuiesta desde el front end.
el api cuenta con useCorse con el origen del frontend angular. genere una carpeta Dtos para mapear las respuestas de los reposritorios de acuerdo a la necesidad del requerimiento. la carpeta queries tiene el querie que calcula la predicion con el dto respectivo en la respuesta del sales date prediction.
los context se encuentran en la carpeta StoreSampleContext. la coneccion de la base de datos  se encuentra configurada en el programs.cs y la coneccion en el appsettings.json ConnectionStrings

# frond end

se desarrollo la parte front con angular 18 utilizando standalone para importacion directa. genere las carpetas Core, Features y Shared para la prueba. Core contiene los servicios, Feature contiene Components,Layouts y Pages. Layout es el contenedor principal de la aplicacion y es en donde se renderiza las rutas hijas. las cuales son las Page customer y notfound. por default se presenta la ruta hija Costumer. en Components se encuentran Search,Table,Modaltable,Modalform y Modal. Search es el buscador y es el encargado de filtrar las ordenes al escribir algun nombre de la tabla. este filtra solo por nombre  y muestra lo que coincida con la data de entrada, Table es el componente que usa customer para presentar la prediccion, Tablemodal muestra el detalle las ordenes de cada cliente dentro del componente Modal. Modalform se muestra al hacer click en new order para crear una nueva orden. Los campos select del formulario shipper,product y employees se traen desde bases de datos. el formulario valida que todos los datos sean obligatorios. en el diseño se utilizo angular material y sweetalert2 en los mensajes del formulario. se manejo Input,Output para el envio 
de datos desde padre e hijo e hijo a padre. esto con el fin de q costumer sea el encargado de manejar las peticiones http. las solicitudes para los campos del formulario se hiceron desde el componente modalForm.
las url de los endpoints  estan en un json en la carpeta api que esta dentro de la carpeta public.
los servicios hacen uso de este archivo para apuntar a las rutas o endpoints del backend.



# Graficando con D3
  A partir de datos ingresados por in input, se pinta una grafica de barras con escala representando el valor de cada uno de los datos, adicional se muestra el valor dentro de la barra para mas informacion

# clonar proyecto

git clone https://github.com/andresmel/pruebaT-cnica.git
cd pruebaT-cnica
cd D3


Este proyecto está compuesto por:
**javascript vanilla** – ubicado en la carpeta D3

# estructura del proyecto

|__D3
    |__css
    |   |__index.css
    !__js
    |   |__controller.js
    |   |__validate-input.js
    |   |__chargenerator.js
    |__index.html



# ejecucion Proyecto D3

Se creo la carpeta D3 y dentro de ella un archivo index, una carpeta js con los archivos controller.js y validate-input.js y chargenerator.js. El archivo controller contiene validaciones de entrada de datos, una validacion para que la entrada de datos contenga comas, o al menos una y despues se convierte ese string con coma a un array numerico donde se valida q el tamañodel array  no sea mayor a 5. A partir de este evento se invoca el metodo "mostrar" el cual se encarga de pintar la grafica con los valores y colores diferentes. el archivo que se encarga de la logica de D3 es el chargenerator.js. por otra parte El archivo validate-input.js tiene un metodo q sirve para q el usuario solo pueda ingresar numeros y comas, no permite  otro tipo de caracteres. el archivo index.css para dar un poco estilos. la grafica se pinta en el div con id imagen. se realizo con la documentacion de D3 y para el uso de esta libreria.



 # Autor
 Andres Melo
 Repositorio: https://github.com/andresmel/pruebaT-cnica

