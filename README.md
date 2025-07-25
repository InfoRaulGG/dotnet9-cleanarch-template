# .NET 9 Clean Architecture Template

A robust and opinionated template for building scalable, maintainable, and testable applications using **.NET 9** and adhering to **Clean Architecture** principles. This template provides a solid foundation, integrating common patterns and best practices, allowing you to focus on your core business logic.

## Table of Contents

* [Features](#-features)

* [Getting Started](#-getting-started)

  * [Prerequisites](#prerequisites)

  * [Cloning the Repository](#cloning-the-repository)

  * [Database Setup (Entity Framework Core)](#database-setup-entity-framework-core)

  * [Running the Application](#running-the-application)

* [Project Structure](#-project-structure)

* [Key Concepts & Patterns](#-key-concepts--patterns)

* [Logging](#-logging)

* [Testing](#-testing)

* [Customization](#-customization)

* [Contributing](#-contributing)

* [License](#-license)

* [Contact](#-contact)

## ✨ Features

* **.NET 9 Ready**: Built with the latest .NET version for enhanced performance and features.

* **Clean Architecture**: Clear separation of concerns into Domain, Application, Infrastructure, and Presentation layers.

* **CQRS (Command Query Responsibility Segregation)**: Implemented with [MediatR](https://github.com/jbogard/MediatR) for clear separation of commands (actions) and queries (data retrieval).

* **Fluent Validation**: Robust input validation using [FluentValidation](https://fluentvalidation.net/).

* **Entity Framework Core**: Data persistence with [EF Core](https://docs.microsoft.com/en-us/ef/core/) (configured for SQL Server).

* **Serilog**: Flexible and powerful logging with [Serilog](https://serilog.net/).

* **ASP.NET Core Identity**: User authentication and authorization.

* **Docker Support**: `Dockerfile` for easy containerization of the Web API.

* **Comprehensive Testing**: Dedicated projects for Unit and Integration Tests using [xUnit](https://xunit.net/) and [Moq](https://github.com/moq/moq4).

* **Swagger/OpenAPI**: Automatic API documentation and testing interface.

* **Dependency Injection**: Built-in .NET Core DI for managing services.

## 🚀 Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

* [Docker Desktop](https://www.docker.com/products/docker-desktop) (Optional, for running with Docker)

* SQL Server (e.g., SQL Server Express, SQL Server LocalDB, or a Dockerized SQL Server instance)

### Cloning the Repository
git clone https://github.com/InfoRaulGG/dotnet9-cleanarch-template.git
cd dotnet9-cleanarch-template