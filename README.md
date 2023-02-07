dotnet run --> Compila el código y hospeda la API

dotnet build --> SOLO compila el código

dotnet tool install -g Microsoft.dotnet-httprepl --> herramienta de línea de comandos .NET HTTP REPL que se va a usar para realizar solicitudes HTTP a la API web.

dotnet dev-certs https --trust --> Para crear un certificado y nos deje usar el localhost

httprepl https://localhost:{PORT} --> Conectarse a la API Alternativa: connect https://localhost:{PORT}

Para acceder a los elementos, es necesario estar en la carpeta de destino

Models --> Objeto Services --> Declaración de los métodos Controllers --> Donde se llaman y ejecutan los métodos

Models << Services << Controllers

Para ver la API --> Postwoman Postman https://localhost:7215/swagger/index.html

dotnet add package Microsoft.EntityFrameworkCore --> Instalar FW EntityFramework
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --> Instalar plugin SQL Server
dotnet add package Microsoft.EntityFrameworkCore.Tools --> Herramientas

dotnet tool install --global dotnet-ef --> herramientas para entity framework

dotnet ef migrations add nombreMigracion --> para añadir la migracion

dotnet ef database update --> para subir la base de datos

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1435:1433 -d mcr.microsoft.com/mssql/server:2022-latest --> para nuestra bd

https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&culture=es-es&country=es&tabs=redhat-install%2Credhat-uninstall --> descargar Azure Data Studio


QUERY PARA CREAR LA BASE DE DATOS

USE master
GO
IF NOT EXISTS (
 SELECT name
 FROM sys.databases
 WHERE name = N'VideojuegoBBDD'
)
 CREATE DATABASE [VideojuegoBBDD];
GO
IF SERVERPROPERTY('VideojuegoBBDD') > '12'
 ALTER DATABASE [VideojuegoBBDD] SET QUERY_STORE=ON;
GO

