# Proyecto de API Web en .NET 8 con GraphQL

Este proyecto implementa una API web utilizando .NET 8 y GraphQL con **Hot Chocolate**. Incluye autenticación y gestión de datos.

## Características del Proyecto

1. **GraphQL con Hot Chocolate**  
   La API utiliza Hot Chocolate para manejar consultas y mutaciones en GraphQL.

2. **Autenticación JWT**  
   La autenticación basada en JSON Web Tokens (JWT) asegura el acceso a la API, protegiendo los endpoints y verificando la identidad del usuario.

3. **Gestión de Datos con Entity Framework Core y SQL Server**  
   Los datos se gestionan mediante **Entity Framework Core**, conectado a una base de datos **SQL Server** para un manejo eficiente y seguro de la persistencia.

## Estructura del Proyecto

- **GraphQL Schema**: Define los tipos, consultas y mutaciones soportadas por la API.
- **Autenticación y Autorización**: Implementada a través de un middleware que valida el JWT en cada solicitud.
- **Contexto de Datos**: Configuración de Entity Framework Core para interactuar con SQL Server y realizar operaciones CRUD.

## Tecnologías Utilizadas

- **.NET 8**
- **Hot Chocolate**
- **JWT para autenticación**
- **Entity Framework Core**
- **SQL Server**

## Requisitos Previos

- **SDK de .NET 8**
- **SQL Server**
- **Postman o una herramienta para probar solicitudes GraphQL**

## Configuración

1. Clonar el repositorio.
2. Configurar la cadena de conexión a SQL Server en el archivo `appsettings.json`.
3. Ejecutar las migraciones para crear la base de datos:  
   ```bash
   dotnet ef database update