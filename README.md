# Employee Task Manager API

An ASP.NET Web API (.NET Core 3.1) project with SQL Server Express as the backend.

Prerequisites:

- .NET Core SDK 3.1 or later
- SQL Server Express or LocalDB
- Visual Studio 2019 or later / VS Code
- Postman or cURL for testing
- Entity Framework Core CLI tools
- Git



Setup Instructions:

```bash

dotnet tool install --global dotnet-ef

git clone

```


## Features

**Employees**

- Add, update, delete employees
- Get a list of employees
- Search employees by name or department

**Tasks**

- Assign tasks to employees
- Mark tasks as pending/completed
- Get tasks by employee

**Database (SQL Server or LocalDB for demo)**

- Employees table
- Tasks table with a foreign key to Employees


## Example API Routes

- GET /api/employees → List all employees
- GET /api/employees/{id} → Get details of one employee
- POST /api/employees → Create employee
- PUT /api/employees/{id} → Update employee
- DELETE /api/employees/{id} → Delete employee
- GET /api/employees/{id}/tasks → Get all tasks for an employee
- POST /api/employees/{id}/tasks → Add a task to employee
- PUT /api/tasks/{taskId} → Update task
- DELETE /api/tasks/{taskId} → Delete task

## Running and Testing

•	Run migrations:

```bash
dotnet ef migrations add InitialCreate

dotnet ef database update
```

You can verify the database and tables are created using SQL Server Management Studio or any SQL client.

```SQL
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'EmployeeTaskManagerDb';

SELECT * FROM Employees;

```

•	Start the API:

```bash
dotnet run
```	

•	Access Swagger UI at http://localhost:<port>/swagger for testing.

Example:
http://localhost:5000/swagger/index.html

## Example cURL commands

Create a new employee:

```bash
curl -X POST "http://localhost:5000/api/employees" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Jane Doe",
    "department": "Engineering",
    "email": "jane.doe@example.com"
  }'
```

or on Windows Command Prompt:

```bash

curl -X POST "http://localhost:5000/api/employees" -H "Content-Type: application/json" -d "{\"name\": \"Jane Doe\", \"department\": \"Engineering\", \"email\": \"jane.doe@example.com\", \"taskItems\": []}"

```


GET all employees:

```bash
curl -X GET "http://localhost:5000/api/Employees" -H  "accept: text/plain"
```

Update an employee:

```bash
curl -X PUT "http://localhost:5000/api/Employees/1" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"employeeId\":1,\"name\":\"Demo User\",\"department\":\"Sales\",\"email\":\"demo.user@sales.com\",\"taskItems\":[]}"
```


## Dependencies

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore (for Swagger)
- Newtonsoft.Json
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Serilog.AspNetCore (for logging)
- FluentValidation.AspNetCore (for input validation)
- Moq (for unit testing)
- xUnit (for unit testing)
- coverlet.collector (for code coverage)
- Microsoft.AspNetCore.Mvc.Versioning (for API versioning)
- Microsoft.AspNetCore.Authentication.JwtBearer (for JWT authentication)
- Microsoft.IdentityModel.Tokens (for token validation)
- System.IdentityModel.Tokens.Jwt (for JWT handling)
- Microsoft.Extensions.Caching.Memory (for in-memory caching)
- Polly (for resilience and transient fault handling)


## Goal - AWS Transform for .NET modernization

- Migration from .NET Core 3.1 to .NET 8.0 for the EmployeeTaskManager project
