using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _studentService.AddStudent(student);
            return Ok("Student added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Student student)
        {
            _studentService.UpdateStudent(student);
            return Ok("Student updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok("Student deleted successfully.");
        }
    }
}