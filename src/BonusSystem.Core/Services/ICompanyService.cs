using BonusSystem.Models.DTOs.Companies;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Core.Services
{
    public interface ICompanyService
    {
        Task<Result<CompanyResponseDto,DomainError>> CreateCompany(CompanyDto request);
        Task<List<Result<CompanyResponseDto,DomainError>>> GetAllCompanies();
    }
}
