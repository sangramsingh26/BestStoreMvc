# ASP.NET MVC Machine Test Project

## Overview
This project is an ASP.NET MVC application developed to demonstrate proficiency in building web applications using the Entity Framework Code First approach (or ADO.NET) without relying on scaffolding. The application provides a straightforward interface for managing categories and products, showcasing CRUD (Create, Read, Update, Delete) operations for both entities. Additionally, it features server-side pagination to efficiently handle and display large datasets.
## Features

1. **Category Master CRUD Operations**
   - Create, Read, Update, and Delete categories.

2. **Product Master CRUD Operations**
   - Create, Read, Update, and Delete products.
   - Each product is associated with a category.

3. **Product List Display**
   - Displays products with the following details:
     - ProductId
     - ProductName
     - CategoryId
     - CategoryName

4. **Server-Side Pagination**
   - Implements pagination on the product list to fetch records based on page size.

## Technologies Used

- ASP.NET MVC
- Entity Framework Code First (or ADO.NET)
- C#
- SQL Server

## Getting Started

1. **Clone the Repository**
   git clone https://github.com/sangramsingh26/BestStoreMv.git

2. **Open in Visual Studio**
   - Open the solution file in Visual Studio 2017 or later.

3. **Configure Database Connection**
   - Update the connection string in `Web.config` to match your SQL Server configuration.

4. **Database Setup**
   - For Entity Framework Code First:
     - Run migrations to create the database.
   - For ADO.NET:
     - Use the provided SQL scripts to set up the database manually.

5. **Run the Application**
   - Start debugging in Visual Studio to launch the application.


