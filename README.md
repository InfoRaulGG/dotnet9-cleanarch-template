# .NET 9 Clean Architecture Template

A professional-grade .NET 9 solution template implementing Clean Architecture, CQRS, MediatR, ASP.NET Core Identity, Entity Framework Core, and more. This template is designed to kickstart enterprise-grade backend solutions with best practices, modularity, and maintainability.

---

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Cloning the Repository](#cloning-the-repository)
  - [Running the Solution](#running-the-solution)
  - [Using Docker](#using-docker)
- [Project Structure](#project-structure)
- [Architecture Overview](#architecture-overview)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- .NET 9 + ASP.NET Core Web API
- Clean Architecture (Domain, Application, Infrastructure, Presentation layers)
- CQRS with MediatR
- Entity Framework Core (SQL Server)
- ASP.NET Core Identity for authentication/authorization
- FluentValidation integration
- Serilog logging
- Dockerfile for containerization
- Swagger/OpenAPI documentation
- Unit & integration tests (xUnit, Moq)
- Modular solution for easy feature additions

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for local development)
- [Docker](https://www.docker.com/) (optional)
- [Git](https://git-scm.com/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Cloning the Repository

```sh
git clone https://github.com/InfoRaulGG/dotnet9-cleanarch-template.git
cd dotnet9-cleanarch-template
```

### Running the Solution

1. **Restore dependencies**
    ```sh
    dotnet restore
    ```

2. **Set up the database**
    - Update the connection string in `src/Infrastructure/Persistence/AppDbContext.cs` or `appsettings.json`.
    - Apply migrations:
      ```sh
      dotnet ef database update --project src/Infrastructure
      ```

3. **Run the API**
    ```sh
    dotnet run --project src/Presentation/Api
    ```
    The API will start at [https://localhost:5001](https://localhost:5001) (by default).

### Using Docker

Build and run the solution in Docker:

```sh
docker build -t cleanarch-app .
docker run -p 5001:5001 cleanarch-app
```

> **Note:** Update your connection string for Docker usage if needed, or use Docker Compose to spin up SQL Server and API together.

---

## Project Structure

```
dotnet9-cleanarch-template/
├── src/
│   ├── Domain/         # Domain entities and interfaces
│   ├── Application/    # Application layer (CQRS, business logic)
│   ├── Infrastructure/ # Infrastructure (EF Core, Identity, external services)
│   └── Presentation/   # API and UI layer
├── tests/              # Unit and integration tests
├── docker-compose.yml  # Multi-container setup
├── Dockerfile          # API container definition
└── README.md
```

---

## Architecture Overview

This template follows the Clean Architecture pattern:
- **Domain:** Core business entities and logic.
- **Application:** Business use cases, CQRS handlers, MediatR requests.
- **Infrastructure:** Data access, identity, and integrations.
- **Presentation:** API controllers, endpoints.

**Diagram:**

```
[Presentation] <-> [Application] <-> [Domain]
                        ^
                        |
                  [Infrastructure]
```

- **CQRS:** All requests are processed via MediatR; commands/queries are separated.
- **EF Core:** Used for persistence, migrations, and data access.
- **Identity:** Integrated for authentication/authorization.

---

## API Documentation

Once running, navigate to `/swagger` or `/swagger/index.html` for interactive API docs and testing.

---

## Testing

- All test projects are under `/tests`.
- Run all tests with:
    ```sh
    dotnet test
    ```
- Unit tests use xUnit and Moq for mocking dependencies.

---

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

Please follow the existing code style and conventions. All contributions are welcome!

---

## License

Licensed under the [MIT License](LICENSE).

---

**Maintainer:** [InfoRaulGG](https://github.com/InfoRaulGG)
