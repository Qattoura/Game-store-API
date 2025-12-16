# 🎮 Game Catalog REST API

A comprehensive backend solution built with **ASP.NET Core** and **C#** to manage a video game store's catalog. This project implements a fully functional RESTful API to perform CRUD (Create, Read, Update, Delete) operations on game records and their associated genres.

The backend uses modern .NET features, including Entity Framework Core for database interaction, Data Transfer Objects (DTOs) for clear contracts, and the asynchronous programming model for efficiency.

## ✨ Features

* **RESTful API:** Provides standard HTTP endpoints (`GET`, `POST`, `PUT`, `DELETE`) for games and genres.
* **CRUD Operations:** Full control over game records (Create, List, Retrieve, Update, Delete).
* **Data Modeling:** Uses a relational database model (implemented via Entity Framework Core).
* **Data Transfer Objects (DTOs):** Enforces a clean data contract between the API and the client applications.
* **Dependency Injection (DI):** Structured service management using the built-in DI container.
* **Configuration System:** Leverages the robust configuration system for managing connection strings and settings.

## 🛠️ Tech Stack

* **Backend Framework:** ASP.NET Core (latest version used in the tutorial)
* **Language:** C#
* **ORM:** Entity Framework Core
* **Development Environment:** Visual Studio Code (VS Code)
* **Database:** Local relational database provider (e.g., SQLite, configured via EF Core)

## 📦 Prerequisites

Before running this project, you need to install the following:

1.  **[.NET SDK](https://dotnet.microsoft.com/download):** Includes everything required to build and run .NET applications.
2.  **[Visual Studio Code](https://code.visualstudio.com/):** A lightweight but powerful source code editor.
3.  **VS Code Extensions:** The tutorial recommends installing the **C# Dev Kit** and other necessary extensions for a smooth development experience.

## 🚀 Getting Started

Follow these steps to get your development environment set up and run the API.

### 1. Clone the Repository

```bash
git clone <repository-url>
cd game-catalog-api
