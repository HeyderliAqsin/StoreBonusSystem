using BonusSystem.Core.Services;
using BonusSystem.Models.Common;
using BonusSystem.Models.DTOs.Companies;
using Microsoft.AspNetCore.Mvc;

namespace BonusSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        private readonly ICompanyService _companyService = companyService;

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyDto request)
        {
            var response = await _companyService.CreateCompany(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var response = await _companyService.GetAllCompanies();
            var apiResponse = ApiResponse.Success(response);
            return Ok(apiResponse);
        }
    }
}
