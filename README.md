# Assignment 1

A ASP.NET Core MVC application that displays a list of products.

## Features
- Displays products in a table.
- Search products by name using a form.
- Uses Tag Helpers for navigation and form posts.
- Logs actions using ILogger.

## How to Run
1. Open the solution in Visual Studio 2022.
2. Make sure you have .NET 6.0 or higher installed.
3. Press F5 to run the app locally.
4. Navigate to /Product/Index to see the product list.

## Dependencies
- ASP.NET Core MVC
- Entity Framework Core
- Visual Studio 2022
- .NET 6.0 or higher

# Assignment 2 

## Design Note: Separation of Concerns & DI

This project introduces a domain service `ITimeProvider` to separate time-related logic from controllers. 
Using an interface and implementation (`TimeProvider`) keeps concerns isolated and makes unit testing simple.

### Dependency Injection (DI) Choice
`ITimeProvider` is registered as a **Singleton** because it is stateless and safe to reuse across requests.
The service is injected via constructor injection into `ProductController`, which uses it in the `Now` action.

## Benefits
- Clear separation of concerns (controllers focus on HTTP flow; services hold domain logic).
- Testability (services can be unit tested in isolation and mocked/substituted if needed).
- Maintainability (loose coupling between components).

# Assignment 3

## Design Note: Routes

- / or /Home/Index = Home page
- /Home/Privacy = Privacy page
- /hello = HelloWorld index page
- /hello/welcome = Welcome page with default name "Guest" and numTimes=1
- /hello/welcome/{name} = Welcome page for a specific name
- /hello/welcome/{name}/{numTimes} = Welcome page for a specific name repeated numTimes
- /movies = List all movies
- /movies/details/{id} = Movie details
- /movies/create = Create movie form
- /movies/edit/{id} = Edit movie form
- /movies/delete/{id} = Delete confirmation
- /Product/Now = Current time page