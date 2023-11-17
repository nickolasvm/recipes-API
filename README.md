# Recipes API

The Recipes API is a RESTful web service built using ASP.NET Core and follows the MVC architecture. It provides CRUD (Create, Read, Update, Delete) operations for managing recipes, users, and comments left by users on recipes.

## Features

- **Recipes CRUD**: Create, retrieve, update, and delete recipes.
- **Users CRUD**: Manage user accounts for interacting with the API.
- **Comments**: Users can leave comments on recipes.
- **RESTful Design**: Follows RESTful principles for a clean and predictable API.

## Technologies Used

- **ASP.NET Core**: The web framework used to build the API.
- **MVC Architecture**: Organizes the code into models, views, and controllers.

## Getting Started

### Prerequisites

Before running the Recipes API, make sure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the Recipes API repository to your local machine:

   ```bash
   git clone git@github.com:nickolasvm/recipes-API.git

2. Navigate to the project directory:

   ```bash
   cd recipes-API/src/recipes-api

3. Install necessary dependencies:

   ```bash
   dotnet restore

4. Run the project:

   ```bash
   dotnet run
   
## API Endpoints

### Recipes

- **GET** /recipe: Retrieve all recipes.
- **GET** /recipe/{recipeName}: Retrieve a specific recipe.
- **POST** /recipe: Create a new recipe.
- **PUT** /recipe/{recipeName}: Update an existing recipe.
- **DELETE** /recipe/{recipeName}: Delete a recipe.

### Users

- **GET** /user/{email}: Retrieve a specific user.
- **POST** /user: Create a new user.
- **PUT** /user{email}: Update an existing user.
- **DELETE** /user{email}: Delete an user.

### Comments

- **GET** /comments/{recipeName}: Retrieve all comments for a recipe.
- **POST** /comment: Add a new comment to a recipe.
