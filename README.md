This solution contains three projects:Employee Management API, BlogPlatform and GitHubApiClient. To setup this solution follow these instructions:

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQLite](https://www.sqlite.org/download.html)
- Visual Studio or VS Code

  ### 1. Clone the Repository

 git clone https://github.com/loreta123/EmployeeManagement.git
 cd EmployeeManagement

To succeessfully configure and run all the applications:

 # Employee Management API

This is an ASP.NET Core Web API for managing employees, providing CRUD operations with JWT-based authentication and role-based access control. The API ensures secure data access and follows RESTful principles.

## Database Setup 

### 1. Update the appsettings.json with your SQL Server connection string

  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS01; Initial Catalog=Employees; Integrated Security=True; MultipleActiveResultSets=True;"
  }
### 2. Apply migrations and seed the database

## JWT Authentication Configuration
configure the JWT issuer and key for token generation. These settings are located in appsettings.json

 "Jwt": {
    "Issuer": "localhost", 
    "Audience": "localhost", 
    "Key": "YourSecretKeyForAuthenticationOfApplication",
    "ExpireTime": "3h" // Token expiration time
  }
  
  ## Run the application

# BlogPlatform

## Database Configuration

### 1.Open appsettings.json and configure your SQL Server connection string:

 "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS01; Initial Catalog=BlogPlatform; Integrated Security=True; MultipleActiveResultSets=True;"
  }

### 2.Apply Migrations

# GitHubApiClient

A simple and lightweight GitHub API client built with C#. This client allows users to interact with the GitHub API, enabling functionalities like retrieving repositories, managing issues, and fetching user details.




