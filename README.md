# Carpro - Clean Architecture Implementation

## Overview

This project is a rewrite of the original Carpro application using clean architecture principles. The application provides a simple API for retrieving vehicle information by registration number.

## Architecture

The solution follows the clean architecture pattern, which emphasizes separation of concerns and dependency inversion. The architecture is divided into the following layers:

### 1. Domain Layer (Carpro.Domain)

The innermost layer containing business logic and entities. It has no dependencies on other layers or external frameworks.

- **Entities**: Contains the Vehicle entity with rich domain behavior
- **Exceptions**: Contains domain-specific exceptions
- **Interfaces**: Contains repository interfaces

### 2. Application Layer (Carpro.Application)

Contains the application logic and orchestrates the domain objects to perform tasks.

- **Common/Behaviors**: Contains MediatR pipeline behaviors for validation and performance logging
- **Common/Exceptions**: Contains application-specific exceptions
- **Common/Interfaces**: Contains interfaces for infrastructure services
- **Vehicles/DTOs**: Contains data transfer objects for the Vehicle entity
- **Vehicles/Queries**: Contains CQRS queries and handlers for vehicle operations

### 3. Infrastructure Layer (Carpro.Infrastructure)

Provides implementations for interfaces defined in the inner layers.

- **Data/Configurations**: Contains entity configurations for Entity Framework Core
- **Data/Repositories**: Contains repository implementations
- **Data/CarproDbContext.cs**: Contains the database context
- **Data/UnitOfWork.cs**: Contains the unit of work implementation

### 4. Presentation Layer (Carpro.Api)

The outermost layer that interacts with users or external systems.

- **Controllers**: Contains API controllers
- **Middleware**: Contains middleware for exception handling
- **Program.cs**: Contains the application startup and configuration

## Technologies Used

- **.NET 8**: The latest version of the .NET framework
- **Entity Framework Core**: For data access
- **MediatR**: For implementing the mediator pattern and CQRS
- **FluentValidation**: For validation
- **Serilog**: For logging
- **Swagger/OpenAPI**: For API documentation

## Design Patterns

- **Clean Architecture**: For separation of concerns and dependency inversion
- **CQRS (Command Query Responsibility Segregation)**: For separating read and write operations
- **Repository Pattern**: For abstracting data access
- **Unit of Work Pattern**: For transaction management
- **Mediator Pattern**: For decoupling request handlers from controllers

## Running the Application

### Prerequisites

- .NET 8 SDK

### Steps

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/Carpro.git
   ```

2. Navigate to the solution directory:
   ```
   cd Carpro
   ```

3. Build the solution:
   ```
   dotnet build
   ```

4. Run the API:
   ```
   cd src/Carpro.Api
   dotnet run
   ```

5. Open a browser and navigate to:
   ```
   https://localhost:5001/swagger
   ```

## API Endpoints

### Get Vehicle by Registration Number

```
GET /api/vehicles/{regNum}
```

**Parameters**:
- `regNum` (path parameter): The registration number of the vehicle to retrieve

**Response**:
- 200 OK: Returns the vehicle information
- 404 Not Found: If the vehicle is not found
- 400 Bad Request: If the registration number is invalid

**Example Response**:
```json
{
  "vehicleRegNum": 23432,
  "vehicleModel": "Toyota",
  "vehicleProdYear": "2020"
}
```

## Improvements Over Original Implementation

1. **Separation of Concerns**: Clear separation between layers with well-defined responsibilities
2. **Rich Domain Model**: Enhanced Vehicle entity with validation and behavior
3. **CQRS Pattern**: Separation of read and write operations
4. **Validation**: Comprehensive validation using FluentValidation
5. **Exception Handling**: Global exception handling with appropriate HTTP status codes
6. **Logging**: Enhanced logging with Serilog
7. **Performance Monitoring**: Logging of long-running requests
8. **Dependency Injection**: Proper registration of services
9. **Unit of Work Pattern**: For transaction management
10. **Repository Pattern**: For abstracting data access
11. **Swagger Documentation**: For API documentation

## Future Enhancements

1. **Authentication and Authorization**: Add JWT-based authentication and role-based authorization
2. **Caching**: Implement caching for frequently accessed data
3. **Unit Tests**: Add comprehensive unit tests for all layers
4. **Integration Tests**: Add integration tests for critical paths
5. **Docker Support**: Add Docker support for containerization
6. **CI/CD Pipeline**: Set up continuous integration and deployment
7. **Health Checks**: Add health checks for monitoring
8. **Rate Limiting**: Add rate limiting for API endpoints
9. **API Versioning**: Add API versioning for backward compatibility
10. **Pagination**: Add pagination for large result sets

