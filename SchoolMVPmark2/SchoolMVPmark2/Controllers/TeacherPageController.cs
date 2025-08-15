using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolMVPmark2.Models;
using System.Net.Http.Json;

namespace SchoolMVPmark2.Controllers
{
    /// <summary>
    /// Handles MVC actions related to listing, viewing, creating, and deleting teacher records.
    /// Also performs API integration to manage data operations.
    /// </summary>
    public class TeacherPageController : Controller
    {
        // Reusable database context instance
        private SchoolDbContext db = new SchoolDbContext();

        /// <summary>
        /// Returns a list of all teachers and loads them into the List view.
        /// GET: /TeacherPage/List
        /// </summary>
        /// <returns>Renders a table of all teachers from the database</returns>
        public IActionResult List()
        {
            var teachers = db.GetAllTeachers();
            return View(teachers);
        }

        /// <summary>
        /// Displays detailed info for a teacher by ID.
        /// GET: /TeacherPage/Show/3
        /// </summary>
        /// <param name="id">The unique teacher ID</param>
        /// <returns>Returns the Show.cshtml view of the selected teacher</returns>
        public IActionResult Show(int id)
        {
            var teacher = db.FindTeacher(id);
            return View(teacher);
        }

        /// <summary>
        /// Loads a blank search form for filtering teachers by hire date.
        /// GET: /TeacherPage/SearchForm
        /// </summary>
        /// <returns>Search form view</returns>
        public IActionResult SearchForm()
        {
            return View();
        }

        /// <summary>
        /// Processes the submitted hire date range and returns matching teachers.
        /// POST: /TeacherPage/SearchResult
        /// </summary>
        /// <param name="minDate">Start of date range</param>
        /// <param name="maxDate">End of date range</param>
        /// <returns>List view of teachers hired within the date range</returns>
        [HttpPost]
        public IActionResult SearchResult(DateTime minDate, DateTime maxDate)
        {
            var teachers = db.GetTeachersByHireDate(minDate, maxDate);
            return View(teachers);
        }

        /// <summary>
        /// Displays a form where users can input new teacher information.
        /// GET: /TeacherPage/Create
        /// </summary>
        /// <returns>View for teacher creation</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Submits the new teacher data to the backend API.
        /// POST: /TeacherPage/Create
        /// </summary>
        /// <param name="teacher">The teacher object submitted from the form</param>
        /// <returns>Redirects to List if successful, otherwise shows error</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7285");

            var response = await client.PostAsJsonAsync("/api/teacherapi/add", teacher);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }

            ViewBag.Error = "Failed to add teacher. Please try again.";
            return View(teacher);
        }

        /// <summary>
        /// Loads a confirmation page before deleting a teacher.
        /// GET: /TeacherPage/DeleteConfirm/5
        /// </summary>
        /// <param name="id">The ID of the teacher to delete</param>
        /// <returns>Delete confirmation page with teacher info</returns>
        public IActionResult DeleteConfirm(int id)
        {
            var teacher = db.FindTeacher(id);
            return View(teacher);
        }

        /// <summary>
        /// Sends a delete request to the API to remove a teacher.
        /// POST: /TeacherPage/Delete
        /// </summary>
        /// <param name="id">Teacher ID to be deleted</param>
        /// <returns>Redirects to List view after deletion attempt</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7285");

            var response = await client.DeleteAsync($"/api/teacherapi/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }

            ViewBag.Error = "Failed to delete the teacher. Please check the ID.";
            return RedirectToAction("List");
        }

        /// GET: /TeacherPage/Edit/5
        public IActionResult Edit(int id)
        {
            var teacher = db.FindTeacher(id);
            if (teacher == null) return RedirectToAction("List");
            return View("~/Views/TeacherPage/Edit.cshtml", teacher);
        }

        // <summary>
        /// POST: /TeacherPage/Edit
        /// Submits updated teacher data to the WebAPI (PUT).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.TeacherFname) ||
                string.IsNullOrWhiteSpace(teacher.TeacherLname) ||
                teacher.Hiredate > DateTime.Now || teacher.Salary < 0)
            {
                ViewBag.Error = "Please fix validation errors.";
                return View("~/Views/TeacherPage/Edit.cshtml", teacher);
            }

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7285");
            var resp = await client.PutAsJsonAsync($"/api/teacherapi/update/{teacher.TeacherId}", teacher);

            if (resp.IsSuccessStatusCode) return RedirectToAction("List");
            ViewBag.Error = "Update failed. Please try again.";
            return View("~/Views/TeacherPage/Edit.cshtml", teacher);
        }
    }
}
