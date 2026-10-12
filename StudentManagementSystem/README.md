# Student Management System (ASP.NET Core MVC)

A web application to manage student records.

## Features
- Add, view, edit and delete students (CRUD)
- Search by name or email, filter by course
- Unique email check, 10-digit phone validation, semester range validation
- Client-side validation (jQuery Validation) plus server-side validation
- Responsive Bootstrap interface, SQL Server database via Entity Framework Core

## Requirements
- Visual Studio 2022 (ASP.NET workload) or .NET 8 SDK
- SQL Server LocalDB or any SQL Server instance

## Run
1. Open `StudentManagementSystem.csproj` in Visual Studio 2022 (or run `dotnet run`).
2. Check the connection string in `appsettings.json`.
3. Press F5. The `StudentManagementDb` database and sample students are created on first run.
4. Open SSMS, connect to `(localdb)\MSSQLLocalDB`, and inspect the `Students` table.

## Folder guide
- `Models/Student.cs` - model and validation rules
- `Data/` - DbContext and sample data
- `Controllers/StudentsController.cs` - all CRUD logic
- `Views/Students/` - Razor pages
- `wwwroot/js/site.js` - small JavaScript helpers
