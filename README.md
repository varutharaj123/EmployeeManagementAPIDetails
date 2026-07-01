# Employee Management API

## Overview

Employee Management API is a RESTful Web API developed using **ASP.NET Core Web API**.  
This project provides CRUD operations to manage employee information such as adding, retrieving, updating, and deleting employee records.

The API follows a clean architecture approach with separation of concerns using Controller, Service, and Repository layers.

---

## Technologies Used

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **C#**
- **LINQ**
- **Dependency Injection**
- **Swagger / OpenAPI**
- **NUnit Unit Testing**
- **Docker Support**

---

## Project Features

### Employee Management

The API supports the following operations:

✅ Add a new employee  
✅ Get all employees  
✅ Get employee details by ID  
✅ Update employee information  
✅ Delete employee record  

---

## API Endpoints

### 1. Get All Employees

```
GET /api/employees
```

Returns the list of all employees.

---

### 2. Get Employee By ID

```
GET /api/employees/{id}
```

Example:

```
GET /api/employees/1
```

Returns employee details based on employee ID.

---

### 3. Create Employee

```
POST /api/employees
```

Request Body:

```json
{
  "employeeName": "John Smith",
  "email": "john.smith@gmail.com",
  "department": "IT",
  "dateOfJoining": "2025-01-15"
}
```

---

### 4. Update Employee

```
PUT /api/employees/{id}
```

Example:

```
PUT /api/employees/1
```

Updates existing employee information.

---

### 5. Delete Employee

```
DELETE /api/employees/{id}
```

Example:

```
DELETE /api/employees/1
```

Deletes an employee record.

---

## Database Design

Employee Table:

| Column | Data Type | Description |
|---|---|---|
| EmployeeId | int | Primary Key |
| EmployeeName | varchar | Employee Name |
| Email | varchar | Employee Email |
| Department | varchar | Employee Department |
| DateOfJoining | datetime | Joining Date |

---

## Project Structure

```
EmployeeManagementAPI

│
├── EmployeeManagement.API
│   ├── Controllers
│   ├── Program.cs
│   └── appsettings.json
│
├── EmployeeManagement.Application
│   ├── Interfaces
│   ├── Services
│   └── DTOs
│
├── EmployeeManagement.Domain
│   └── Entities
│
├── EmployeeManagement.Infrastructure
│   ├── Data
│   └── Repository
│
└── EmployeeManagement.Tests
    └── Unit Tests
```

---

## Setup Instructions

### 1. Clone Repository

```bash
git clone https://github.com/varutharaj123/EmployeeManagementAPI.git
```

---

### 2. Configure Database Connection

Update the connection string in:

```
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

### 3. Apply Database Migration

Run the following commands:

```bash
dotnet ef database update
```

---

### 4. Run Application

```bash
dotnet run
```

---

## Swagger Documentation

After running the application, open:

```
https://localhost:<port>/swagger
```

Swagger UI provides interactive API testing.

---

## Unit Testing

Unit tests are implemented using:

- NUnit
- Moq
- Dependency Injection

Test cases cover:

- Employee creation
- Employee retrieval
- Employee update
- Employee deletion

Run tests:

```bash
dotnet test
```

---

## Design Principles Followed

- Clean Architecture
- SOLID Principles
- Repository Pattern
- Dependency Injection
- Async Programming
- Separation of Concerns

---

## Future Enhancements

- JWT Authentication
- Role-Based Authorization
- Pagination and Filtering
- Logging using Serilog
- Global Exception Handling
- Azure Deployment

---

## Author

**Varutharaj Jayaraj**
