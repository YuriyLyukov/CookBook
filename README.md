# CookBook
This is a solution for creating Recipe Book (SPA) with Angular and ASP.NET Core.

## Technologies

* ASP.NET Core 3
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [Angular 11](https://angular.io/)
* XUnit

## Getting Started
1. Install the latest [.NET 3 SDK](https://dotnet.microsoft.com/download/dotnet/3.0)
2. Install the latest [Node.js LTS](https://nodejs.org/en/)
3. Navigate to `client` and run `npm install`
4. Navigate to `client` and run `npm start` to launch the front end (Angular)
5. Navigate to `API` and run `dotnet restore`
6. Change the SQLServer database connection string in `API/appsettings.json`
7. Navigate to `API` and run `dotnet run` to launch the back end (ASP.NET Core Web API)
