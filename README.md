.NET 9 Clean Architecture Template
A robust and opinionated template for building scalable, maintainable, and testable applications using .NET 9 and adhering to Clean Architecture principles. This template provides a solid foundation, integrating common patterns and best practices, allowing you to focus on your core business logic.

✨ Features
.NET 9 Ready: Built with the latest .NET version for enhanced performance and features.

Clean Architecture: Clear separation of concerns into Domain, Application, Infrastructure, and Presentation layers.

CQRS (Command Query Responsibility Segregation): Implemented with MediatR for clear separation of commands (actions) and queries (data retrieval).

Fluent Validation: Robust input validation using FluentValidation.

Entity Framework Core: Data persistence with EF Core (configured for SQL Server).

Serilog: Flexible and powerful logging with Serilog.

ASP.NET Core Identity: User authentication and authorization.

Docker Support: Dockerfile for easy containerization of the Web API.

Comprehensive Testing: Dedicated projects for Unit and Integration Tests using xUnit and Moq.

Swagger/OpenAPI: Automatic API documentation and testing interface.

Dependency Injection: Built-in .NET Core DI for managing services.

🚀 Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Prerequisites
.NET 9 SDK

Docker Desktop (Optional, for running with Docker)

SQL Server (e.g., SQL Server Express, SQL Server LocalDB, or a Dockerized SQL Server instance)

Cloning the Repository
git clone https://github.com/InfoRaulGG/dotnet9-cleanarch-template.git
cd dotnet9-cleanarch-template

Database Setup (Entity Framework Core)
The template uses Entity Framework Core for data persistence. You'll need to apply migrations to create the database schema.

Configure Connection String:
Open src/Presentation/WebAPI/appsettings.json and update the DefaultConnection string to point to your SQL Server instance.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CleanArchitectureDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // ... other settings
}

Apply Migrations:
Open your terminal in the root directory of the project and run the following commands to apply existing migrations and create the database:

dotnet ef database update --project src/Infrastructure --startup-project src/Presentation/WebAPI

If you need to create new migrations (e.g., after adding new entities), use:

dotnet ef migrations add YourMigrationName --project src/Infrastructure --startup-project src/Presentation/WebAPI

Running the Application
1. Locally with .NET CLI
Navigate to the src/Presentation/WebAPI directory and run the application:

cd src/Presentation/WebAPI
dotnet run

The API will typically run on https://localhost:7000 and http://localhost:5000. You can access the Swagger UI at https://localhost:7000/swagger (or http://localhost:5000/swagger).

2. Using Docker
The src/Presentation/WebAPI project includes a Dockerfile.

Build the Docker Image:
Navigate to the src/Presentation/WebAPI directory:

cd src/Presentation/WebAPI
docker build -t dotnet9-cleanarch-api .

Run the Docker Container:
You'll need to ensure your database is accessible from within the Docker container. If your SQL Server is running locally on your host, you might need to use host.docker.internal as the server address in your connection string (for Docker Desktop on Windows/macOS).

docker run -p 7000:8080 -p 5000:8081 dotnet9-cleanarch-api

-p 7000:8080: Maps host port 7000 to container's HTTP port 8080 (default for .NET 8+ Docker images).

-p 5000:8081: Maps host port 5000 to container's HTTPS port 8081.

Access the API at http://localhost:7000/swagger or https://localhost:5000/swagger.

📂 Project Structure
The repository follows the standard Clean Architecture layering:

src/: Contains the core application projects.

Application/: Defines the use cases and application-specific business rules. It depends only on the Domain layer.

Features/: Contains CQRS commands, queries, and their handlers.

Common/: Common application-level interfaces and types.

Interfaces/: Interfaces for services provided by the Infrastructure layer.

Domain/: The heart of the business logic. Contains entities, value objects, domain events, and interfaces for repositories. It has no dependencies on other layers.

Entities/: Your core business objects.

Common/: Base classes for entities, domain events.

Events/: Domain events.

Exceptions/: Custom domain-specific exceptions.

Infrastructure/: Implements interfaces defined in the Application and Domain layers. Handles data access, external services, and identity management. It depends on Application and Domain.

Persistence/: Entity Framework Core DbContext, migrations, and repository implementations.

Identity/: ASP.NET Core Identity setup.

Services/: Implementations of external services (e.g., email sender, date time service).

Presentation/WebAPI/: The entry point for the application, exposing API endpoints. It depends on Application and Infrastructure.

Controllers/: ASP.NET Core API controllers.

Program.cs: Application startup, DI configuration, middleware setup.

tests/: Contains testing projects.

Application.UnitTests/: Unit tests for the Application layer.

Domain.UnitTests/: Unit tests for the Domain layer.

Infrastructure.IntegrationTests/: Integration tests for the Infrastructure layer (e.g., database interactions).

WebAPI.IntegrationTests/: Integration tests for the WebAPI endpoints.

💡 Key Concepts & Patterns
Separation of Concerns: Each layer has a specific responsibility, promoting modularity and maintainability.

Dependency Inversion Principle: High-level modules do not depend on low-level modules; both depend on abstractions.

CQRS: Commands modify state, Queries retrieve state. This pattern helps simplify complex operations and scale read/write operations independently.

MediatR: An in-process mediator that helps implement CQRS by decoupling senders from handlers.

Domain-Driven Design (DDD) Lite: Focus on the domain model and business logic.

📝 Logging
This template integrates Serilog for structured logging. You can configure Serilog sinks (e.g., Console, File, Seq, Azure Application Insights) in appsettings.json or Program.cs.

Example configuration in appsettings.json:

{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log-.txt",
          "rollingInterval": "Day",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithMachineName", "WithProcessId", "WithThreadId" ],
    "Properties": {
      "Application": "CleanArchitectureTemplate"
    }
  }
}

🧪 Testing
The template includes a comprehensive testing setup:

Unit Tests: Located in tests/Application.UnitTests and tests/Domain.UnitTests. These tests verify individual components in isolation, mocking dependencies.

Integration Tests: Located in tests/Infrastructure.IntegrationTests and tests/WebAPI.IntegrationTests. These tests verify the interaction between multiple components or layers, often involving a real database (e.g., an in-memory database or a test container).

To run all tests:

dotnet test

🛠️ Customization
This template is designed to be a starting point. Here are some common customization points:

Add New Entities: Create new entities in the Domain layer and add them to ApplicationDbContext in Infrastructure/Persistence. Remember to add a new migration.

Implement New Use Cases: Create new commands/queries and their handlers in the Application layer.

Change Database Provider: Modify Infrastructure/Persistence/DependencyInjection.cs to use a different EF Core provider (e.g., PostgreSQL, MySQL, SQLite).

Add Authentication/Authorization: Extend the Identity system with custom user properties or roles.

Integrate External Services: Add new service interfaces in Application/Interfaces and their implementations in Infrastructure/Services.

🤝 Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.

Fork the Project

Create your Feature Branch (git checkout -b feature/AmazingFeature)

Commit your Changes (git commit -m 'Add some AmazingFeature')

Push to the Branch (git push origin feature/AmazingFeature)

Open a Pull Request

📄 License
Distributed under the MIT License. See LICENSE for more information.

📧 Contact
Raul Garcia - GitHub Profile

Project Link: https://github.com/InfoRaulGG/dotnet9-cleanarch-template