# Tennis Player Stats API

A REST API to manage tennis player statistics, built using .NET 8 with Clean Architecture and MediatR pattern.

## Architecture

This project follows Clean Architecture principles, ensuring separation of concerns and maintainability. Key layers:

- **Domain**: Contains core entity classes representing objects
- **Application**: Contains CQRS pattern implementation using MediatR for handling commands and queries.
- **Infrastructure**: Contains the data access layer with Entity Framework Core and repository pattern.
- **WebApi**: Presentation layer exposing RESTful endpoints

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Setup Instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repository/tennis-player-stats-api.git
   cd TennisProjectCleanArchitecture
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```

4. Run the application:

   ```bash
   dotnet run --project WebApi
   ```

5. The API will be available at:

   - Swagger UI: [http://localhost:5187/swagger](http://localhost:5187/swagger)

## Configuration

### Database Initialization

The application uses an in-memory database, initialized from a JSON file (`tennisData.json`).

### Swagger Documentation

Swagger is enabled by default in development mode. Access it at:

```
https://localhost:5001/swagger
```

### Verifying API Responses

- `GET /players`: Returns all players sorted by ID.
- `GET /players/{id}`: Returns a player by ID or `404` if not found.
- `DELETE /players/{id}`: Deletes a player by ID or returns `404` if not found.
