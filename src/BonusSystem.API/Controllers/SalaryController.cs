using BonusSystem.Core.Services;
using BonusSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace BonusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Get salary for employee", Description = "Retrieves salary for employee by the provided ID.")]
        public async Task<IActionResult> GetSalaryAsync(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            var salaryRecord = await _salaryService.CalculateSalaryForMonth(employeeId,startDate,endDate);
            return Ok(salaryRecord);
        }
    }
}
