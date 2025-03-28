using BonusSystem.Core.Attributes;
using BonusSystem.Core.Services;
using BonusSystem.Models.Common;
using BonusSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace BonusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpPost]
        [Transaction]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Create employee",
        Description = "Creates a new employee based on the provided employee details.")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponseDto>), StatusCodes.Status200OK)]

        public async Task<IActionResult> Create(EmployeeDto request)
        {
            var response = await _employeeService.CreateEmployee(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Get employee by ID", Description = "Retrieves an employee by the provided ID.")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _employeeService.GetEmployeeById(id);
            return Ok(response);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Get all employees", Description = "Retrieves all employees.")]
        [ProducesResponseType(typeof(ApiResponse<List<EmployeeResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _employeeService.GetAllEmployees();
            var apiResponse = ApiResponse.Success(response);
            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Delete employee by ID", Description = "Deletes an employee by the provided ID.")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)] 
        public IActionResult RemoveEmployee(Guid id)
        {
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }

    }
}
