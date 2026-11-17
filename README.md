# TicketForge
A production-oriented event ticketing backend built with **C# and ASP.NET Core**. The project aims to solve real-world ticketing challenges, including event management, seat availability, concurrent bookings, temporary reservations, payment processing, and reliable ticket issuance.

The application is developed incrementally, with an emphasis on understanding backend engineering principles, solving production problems, and building maintainable software.

## Architecture

The application follows a **Modular Monolith** architecture.

Instead of starting with microservices, the system is initially developed as one deployable application divided into independent business modules.

This approach provides:

- Clear boundaries between business domains.
- Independent module responsibilities.
- Controlled communication through explicit contracts.
- Simpler deployment and debugging compared to distributed services.
- A foundation for extracting individual modules into microservices when justified.

### Architectural principles

- Clean Architecture and separation of concerns.
- Dependency Inversion Principle (DIP).
- Dependency Injection (DI).
- Encapsulation and explicit module boundaries.
- Domain-driven design principles where appropriate.
- Testability and maintainability.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# / .NET | Backend development |
| ASP.NET Core Web API | HTTP API |
| PostgreSQL | Relational database |
| Entity Framework Core | ORM and database operations |
| Dapper | Lightweight SQL queries |
| Redis | Caching and distributed coordination |
| RabbitMQ | Asynchronous messaging |
| Docker | Containerization |
| Docker Compose | Local infrastructure |
| JWT | Authentication and authorization |
| xUnit | Automated testing |

Additional technologies and patterns will be introduced as the project evolves.

## Project Structure

```text
EventTicketing/
│
├── EventTicketing.sln
│
├── EventTicketing.WebApi/
│   ├── Program.cs
│   └── Configuration/
│
├── Modules/
│   └── Catalog/
│       ├── Catalog.Module/
│       ├── Catalog.Contracts/
│       ├── Catalog.Domain/
│       ├── Catalog.Application/
│       └── Catalog.Infrastructure/
│
├── BuildingBlocks/
│
├── tests/
│   ├── Catalog.UnitTests/
│   └── Catalog.IntegrationTests/
│
├── docker-compose.yml
├── .env.example
├── .gitignore
└── README.md
```

*Note: This is the planned structure. Additional modules and test projects will be introduced as development progresses.*

### Module responsibilities

| Project | Responsibility |
|---|---|
| WebApi | Application host and HTTP entry point |
| Module | Module registration and endpoint integration |
| Contracts | Public interfaces and DTOs for inter-module communication |
| Domain | Business entities, value objects, and domain rules |
| Application | Use cases and application orchestration |
| Infrastructure | Database access and external service implementations |

## Prerequisites

Before running the application, install:

- [.NET SDK](https://dotnet.microsoft.com/download) — version specified by the solution's target framework.
- [Docker Desktop](https://www.docker.com/products/docker-desktop/).
- Git.

Verify your installations:

```bash
dotnet --version
docker --version
docker compose version
```

## Getting Started

### 1. Clone the repository

```bash
git clone <REPOSITORY_URL>
cd EventTicketing
```

### 2. Configure environment variables

Create your local environment file from the example:

**Windows PowerShell:**

```powershell
Copy-Item .env.example .env
```

**Linux / macOS:**

```bash
cp .env.example .env
```

Update the configuration values for your local environment.

Never commit your actual `.env` file or real credentials.

### 3. Start infrastructure

Start the required infrastructure using Docker Compose:

```bash
docker compose up -d
```

### 4. Restore dependencies

```bash
dotnet restore
```

### 5. Build the solution

```bash
dotnet build
```

### 6. Run the application

```bash
dotnet run --project EventTicketing.WebApi
```

The application URL and health endpoint will be documented here once the API configuration is finalized.

## Running Tests

Run all automated tests:

```bash
dotnet test
```

Run a specific test project:

```bash
dotnet test tests/Catalog.UnitTests
```

Integration tests will be configured to validate interactions with infrastructure components such as PostgreSQL.

## Development Roadmap

The project is developed incrementally, with each stage introducing new engineering concepts and challenges.

- [ ] Solution structure and architectural boundaries.
- [ ] Catalog module and domain modeling.
- [ ] Database integration with PostgreSQL.
- [ ] Entity Framework Core and Dapper.
- [ ] Authentication and authorization using JWT.
- [ ] Ordering module.
- [ ] Concurrency control and transaction management.
- [ ] Idempotency and duplicate request protection.
- [ ] Redis caching.
- [ ] RabbitMQ messaging.
- [ ] Inbox and Outbox patterns.
- [ ] Logging, monitoring and observability.
- [ ] Unit and integration testing.
- [ ] Docker and CI/CD integration.
- [ ] Performance optimization.
- [ ] Kubernetes deployment exploration.

## Development Philosophy

This is not intended to be just another CRUD application.

The goal is to understand how production backend systems are designed, implemented, tested, and maintained.

Features will be introduced alongside the engineering challenges they create, including concurrency, data consistency, failure handling, performance, and system reliability.

**The focus is on understanding why a solution is needed, not simply implementing a technology because it is popular.**