# SchoolMVP - Cumulative Project Part 1

By: Pengcheng Li  
Course: HTTP 5125  
Instructor: Christine Bittle

## Overview

This ASP.NET Core MVC & Web API project connects to a MySQL `school` database and implements **READ** functionality for the `teachers` table.

## Key Files

- `/Models/Teacher.cs` – Teacher model with properties
- `/Models/SchoolDbContext.cs` – Connects to MySQL
- `/Controllers/TeacherAPIController.cs` – API controller
- `/Controllers/TeacherPageController.cs` – MVC controller
- `/Views/Teacher/List.cshtml` – List of teachers
- `/Views/Teacher/Show.cshtml` – One teacher's details

## 🔗 Features Implemented

-  API: `GET /api/teacher/GetAllTeachers`
-  API: `GET /api/teacher/FindTeacher/{id}`
-  MVC Page: `/Teacher/List`
-  MVC Page: `/Teacher/Show/{id}`

## Testing

- API tested using Swagger and `curl` (screenshots in PDF)
