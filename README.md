# 🍽️ Restaurants API  

## 📌 Overview  
**RestaurantsAPI** is a **.NET 8 Web API** project built using **Clean Architecture principles**. It follows the **CQRS pattern** with **MediatR**, leverages **Entity Framework Core** for data access, uses **ASP.NET Identity** for authentication & authorization, and integrates **Serilog** for logging.  

This project serves as a **backend** for a restaurant management web application. It enables users to:  
- Create, read, update, and delete (CRUD) restaurants, dishes, categories, and more.  
- Authenticate and authorize users with role-based access.  
- Log application activities and errors to files.  

---

## 🚀 Features  
- **Database**: Auto-generated MS SQL Server database from C# entity classes using EF Core.  
- **Authentication & Authorization**:  
  - JWT-based authentication.  
  - ASP.NET Identity for managing users & roles.  
- **CQRS with MediatR**:  
  - **Commands** → modify application state (e.g., AddRestaurant, UpdateDish).  
  - **Queries** → read application state (e.g., GetRestaurants, GetOrders).  
- **Middleware**: Custom error handling middleware for consistent API responses.  
- **Logging**: Centralized logging with Serilog (info, warnings, and errors written to text files).  

---

## 🏗️ Project Structure  


├─ Restaurants.API
│ └─ Entry point (controllers, middleware, dependency injection)
│
├─ Restaurants.Application
│ └─ Application logic (CQRS, handlers, validators, DTOs)
│
├─ Restaurants.Domain
│ └─ Core entities, value objects, domain events, enums
│
└─ Restaurants.Infrastructure
└─ EF Core, persistence, repositories, identity, external services

---

## 📦 Packages & Libraries  

- **[Serilog](https://serilog.net/):** Logging framework to write logs into files.  
- **[MediatR](https://github.com/jbogard/MediatR):** Implements the CQRS pattern (Commands & Queries).  
- **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/):** ORM for database interactions.  
- **[Microsoft Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity):** Provides authentication, authorization, and role management.  
- **[FluentValidation](https://docs.fluentvalidation.net/en/latest/)** (if used): For input validation.  

---

🔐 Authentication

User Registration & Login:

New users can register with email & password.

Login returns a JWT token used for secure API access.

Authorization:

Role-based authorization (e.g., Owner, User, Client).

Some endpoints are restricted to Owners only.

---
📝 Logging

Serilog is configured to log into:

Logs/log-.txt (rolling daily log files).

Log Levels: Information, Warning, Error.

Example log entry:
```
[2025-09-04 18:45:32 INF] Restaurant created with ID: 12
```


