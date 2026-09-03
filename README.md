# Student Management System

A desktop application built with **C# Windows Forms** and **MySQL** for managing student records through a simple, intuitive interface. This project demonstrates core CRUD (Create, Read, Update, Delete) operations backed by a relational database.

## Overview

The Student Management System allows users to add, view, update, and delete student records through a clean dashboard interface. It was built as a learning project to apply fundamental concepts of desktop application development, database connectivity, and input validation.

## Features

- **Dashboard** — Central navigation hub linking to all modules
- **View Students** — Displays all student records in a searchable grid (DataGridView)
- **Add Student** — Inserts new student records with input validation:
  - Full Name accepts letters only
  - Email must follow a valid email format
  - Phone number must be exactly 11 digits
- **Update Student** — Search by Roll No or Full Name, load existing details, and update them
- **Delete Student** — Search and remove a record, with a confirmation prompt to prevent accidental deletion
- **Exit** — Safely closes the application

## Tech Stack

| Layer | Technology |
|---|---|
| UI / Frontend | C# Windows Forms (.NET Framework 4.7.2) |
| Database | MySQL |
| Connectivity | MySQL Connector/NET (`MySql.Data`) |
| IDE | Visual Studio |

## Database Schema

```sql
CREATE DATABASE student_management;
USE student_management;

CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    roll_no VARCHAR(20) NOT NULL UNIQUE,
    full_name VARCHAR(100) NOT NULL,
    department VARCHAR(50),
    semester INT,
    email VARCHAR(100),
    phone VARCHAR(20)
);
```

## Getting Started

### Prerequisites

- Visual Studio (2019 or later) with .NET Framework 4.7.2
- MySQL Server and MySQL Workbench
- MySQL Connector/NET NuGet package (`MySql.Data`)

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/Fatima-art12/StudentManagementSystem.git
   ```
2. Open the solution file in Visual Studio.
3. Run the database schema above in MySQL Workbench to create the database and table.
4. Update the connection string in each form's code file to match your local MySQL credentials:
   ```csharp
   string connectionString = "Server=localhost;Database=student_management;Uid=root;Pwd=YOUR_PASSWORD;";
   ```
5. Build and run the project (`F5`).

## Project Structure

```
StudentManagementSystems/
├── Dashboard.cs              # Main menu / navigation
├── FrmViewStudents.cs        # View all students
├── FrmAddStudent.cs          # Add a new student
├── FrmUpdateStudent.cs       # Search and update a student
├── FrmDeleteStudent.cs       # Search and delete a student
└── Program.cs                # Application entry point
```

## Screenshots

<img width="619" height="481" alt="image" src="https://github.com/user-attachments/assets/e115a15f-d4ba-499a-84fc-1f95acf07579" />
<img width="802" height="483" alt="image" src="https://github.com/user-attachments/assets/d483b19f-bd4b-47fe-b1cd-1dff5c42b477" />
<img width="799" height="477" alt="image" src="https://github.com/user-attachments/assets/516cb5ca-97dd-4eb5-887a-fbd869c16e6b" />
<img width="697" height="457" alt="image" src="https://github.com/user-attachments/assets/af234cfa-0a92-4555-8240-51e872ab7f8d" />
<img width="626" height="483" alt="image" src="https://github.com/user-attachments/assets/fd98f26b-c5d0-42fb-aa1f-7cb88d5a59a7" />

## Author

**Fatima Aboul** ([@Fatima-art12](https://github.com/Fatima-art12))
BS Computer Science Student

## License

This project is open for educational and personal use.
