Teacher Management System (SchoolMVPmark2)

This is a small project I built using ASP.NET Core MVC and a Web API. Its main function is to manage teacher information, including viewing, adding, and deleting. The database used is MySQL.

## Project Description

- The web page allows you to view the teacher list, add teachers, and delete teachers.
- The API can also be used to perform the same operations.
- The data comes from a local MySQL database.
- API testing was done using curl, and page operations were tested in a browser.

## Implementing Functionality

- [x] View the teacher list `/TeacherPage/List`
- [x] View individual teacher details `/TeacherPage/Show/{id}`
- [x] Create a teacher `/TeacherPage/Create`
- [x] Delete a teacher `/TeacherPage/DeleteConfirm/{id}`
- [x] Add a teacher using the API `/api/teacherapi/add`
- [x] Delete a teacher using the API `/api/teacherapi/delete/{id}`