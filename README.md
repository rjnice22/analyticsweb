RecordFlow
Project Description

RecordFlow is a secure, database-driven web application built using ASP.NET Core Razor Pages and Entity Framework Core. The application allows authenticated users to create, search, edit, and delete records through a clean and structured interface.

This project demonstrates full CRUD functionality, secure authentication practices, wildcard search capabilities, and structured version control using Git and GitHub. It is designed to reflect production-level development standards and portfolio-quality work.

Core Features

Secure user authentication using ASP.NET Core Identity

Enforced password complexity requirements

Admin account seeding at application startup

Full CRUD functionality (Create, Read, Update, Delete)

Wildcard search using * character

Real-time display of changes after edit or delete

Persistent data storage using Entity Framework Core

Redirect logic that preserves search filters

Clean Razor Pages architecture

Security Measures Implemented

RecordFlow goes beyond basic authentication by implementing multiple security best practices:

Password complexity enforcement (minimum length, uppercase, lowercase, digit, special character)

Global authentication enforcement

Anti-forgery token protection on all POST requests

Entity Framework parameterized queries to prevent SQL injection

Authorization attributes on protected pages

Concurrency handling during record updates

Secure admin account seeding with password reset enforcement

Technologies Used

ASP.NET Core Razor Pages

Entity Framework Core

Microsoft Identity

SQL Server / LocalDB

Bootstrap for UI styling

Git and GitHub for version control
