dotnet run --> Compila el código y hospeda la API

dotnet build --> SOLO compila el código

dotnet tool install -g Microsoft.dotnet-httprepl --> herramienta de línea de comandos .NET HTTP REPL que se va a usar para realizar solicitudes HTTP a la API web.

dotnet dev-certs https --trust --> Para crear un certificado y nos deje usar el localhost

httprepl https://localhost:{PORT} --> Conectarse a la API Alternativa: connect https://localhost:{PORT}

Para acceder a los elementos, es necesario estar en la carpeta de destino

Models --> Objeto Services --> Declaración de los métodos Controllers --> Donde se llaman y ejecutan los métodos

Models << Services << Controllers

Para ver la API --> Postwoman Postman https://localhost:7215/swagger/index.html