using BonusSystem.Core.Services;
using BonusSystem.Models.DTOs.Employees.Create;
using Microsoft.AspNetCore.Mvc;

namespace BonusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpPost]
        public IActionResult Create(EmployeeCreateDto request)
        {
            var response = _employeeService.CreateEmployee(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _employeeService.GetById(id);
            return Ok(response);
        }
    }
}
