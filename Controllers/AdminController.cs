using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_adminService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = _adminService.Get(id);
            if (admin == null || admin.Count == 0) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            _adminService.Add(admin);
            return Ok("Admin added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Admin admin)
        {
            _adminService.Update(admin);
            return Ok("Admin updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adminService.Delete(id);
            return Ok("Admin deleted successfully.");
        }
    }
}