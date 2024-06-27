# NorthWND-Api

![C#](https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png) ![ASP.NET](https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg) ![Entity Framework Core](https://upload.wikimedia.org/wikipedia/commons/6/68/Entity_Framework.png) ![MSSQL](https://upload.wikimedia.org/wikipedia/commons/8/87/Microsoft_SQL_Server_Logo.png) ![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/2/29/Postgresql_elephant.svg) ![Visual Studio](https://upload.wikimedia.org/wikipedia/commons/5/59/Visual_Studio_Icon_2019.svg) ![Git](https://upload.wikimedia.org/wikipedia/commons/e/e0/Git-logo.svg) ![GitHub](https://upload.wikimedia.org/wikipedia/commons/9/91/Octicons-mark-github.svg)

## Project Description

NorthWND-Api is a sample ASP.NET Core Web API project using Entity Framework Core for data access and supporting multiple databases including MSSQL and PostgreSQL.

## Technologies Used

### Backend
- ![C#](https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png) C#
- ![ASP.NET](https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg) ASP.NET Core
- ![Entity Framework Core](https://upload.wikimedia.org/wikipedia/commons/6/68/Entity_Framework.png) Entity Framework Core

### Databases
- ![MSSQL](https://upload.wikimedia.org/wikipedia/commons/8/87/Microsoft_SQL_Server_Logo.png) MSSQL
- ![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/2/29/Postgresql_elephant.svg) PostgreSQL

### Tools
- ![Visual Studio](https://upload.wikimedia.org/wikipedia/commons/5/59/Visual_Studio_Icon_2019.svg) Visual Studio
- ![Git](https://upload.wikimedia.org/wikipedia/commons/e/e0/Git-logo.svg) Git
- ![GitHub](https://upload.wikimedia.org/wikipedia/commons/9/91/Octicons-mark-github.svg) GitHub

## API Documentation

### Base URL
`https://api.yourproject.com`

### Endpoints

#### Get All Items

- **URL**: `/api/items`
- **Method**: `GET`
- **Description**: Retrieve a list of all items.
- **Response**:
    ```json
    [
        {
            "id": 1,
            "name": "Item 1",
            "description": "Description of Item 1"
        },
        {
            "id": 2,
            "name": "Item 2",
            "description": "Description of Item 2"
        }
    ]
    ```

#### Get Item by ID

- **URL**: `/api/items/{id}`
- **Method**: `GET`
- **Description**: Retrieve a single item by its ID.
- **Parameters**:
    - `id` (integer, required): The ID of the item to retrieve.
- **Response**:
    ```json
    {
        "id": 1,
        "name": "Item 1",
        "description": "Description of Item 1"
    }
    ```

#### Create New Item

- **URL**: `/api/items`
- **Method**: `POST`
- **Description**: Create a new item.
- **Request Body**:
    ```json
    {
        "name": "New Item",
        "description": "Description of the new item"
    }
    ```
- **Response**:
    ```json
    {
        "id": 3,
        "name": "New Item",
        "description": "Description of the new item"
    }
    ```

#### Update Item

- **URL**: `/api/items/{id}`
- **Method**: `PUT`
- **Description**: Update an existing item.
- **Parameters**:
    - `id` (integer, required): The ID of the item to update.
- **Request Body**:
    ```json
    {
        "name": "Updated Item",
        "description": "Updated description of the item"
    }
    ```
- **Response**:
    ```json
    {
        "id": 1,
        "name": "Updated Item",
        "description": "Updated description of the item"
    }
    ```

#### Delete Item

- **URL**: `/api/items/{id}`
- **Method**: `DELETE`
- **Description**: Delete an item by its ID.
- **Parameters**:
    - `id` (integer, required): The ID of the item to delete.
- **Response**:
    ```json
    {
        "message": "Item deleted successfully"
    }
    ```

## Getting Started

To get started with this project, clone the repository and follow the instructions below.

```bash
git clone https://github.com/danismazismail/NorthWND-Api.git
cd NorthWND-Api
