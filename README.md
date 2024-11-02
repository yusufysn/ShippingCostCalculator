# ShippingCostCalculator

## Overview
ShippingCostCalculator is a .NET Core 6 API project designed to calculate shipping costs based on various factors, including carrier and package weight. It leverages MSSQL for data storage and follows best practices with Swagger UI, Entity Framework (Code-First), the Repository Design Pattern, and Onion Architecture for scalability and maintainability.

## Features
- **.NET Core 6 API**: Modern, lightweight, and fast.
- **MSSQL**: Reliable and efficient relational database system.
- **Swagger UI**: Interactive documentation to test and visualize API endpoints.
- **Entity Framework (Code-First)**: Simplifies database management through C# models.
- **Repository Design Pattern**: Encapsulates database interactions to ensure separation of concerns.
- **Onion Architecture**: Improves project modularity, making it adaptable and testable.

## Technologies Used
- **.NET Core 6**
- **Entity Framework Core**
- **MSSQL**
- **Swagger**
- **Onion Architecture**

## Getting Started

### Prerequisites
- .NET 6 SDK
- MSSQL Server
- Visual Studio / VS Code

### Installation

1. **Clone the repository**
    ```bash
    git clone https://github.com/yusufysn/ShippingCostCalculator.git
    ```
2. **Configure Database**
   - Update the connection string in `appsettings.json` to point to your MSSQL database.

3. **Apply Migrations**
    ```bash
    update-database
    ```

4. **Run the Application**
    ```bash
    cd Presentation/DotNetChallange.API
    dotnet run
    ```
5. **Access Swagger UI**
   - Visit `http://localhost:{PORT}/swagger` to view API documentation.

## Project Structure
This project follows Onion Architecture, which divides the code into distinct layers:

- **API Layer**: Exposes endpoints for shipping cost calculations.
- **Application Layer**: Contains business logic.
- **Persistence Layer**: Database context and migrations (Entity Framework).
- **Domain Layer**: Core models and shared logic.

## Usage

Use the endpoints in Swagger to interact with the API:
- **Add Carrier**: Adds a new carrier with cost configurations.
- **Calculate Shipping Cost**: Calculates cost based on specified criteria.

---
