using Azure;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Core.Services;
using BonusSystem.Models.DTOs.Companies;
using BonusSystem.Models.DTOs.Employees;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result<CompanyResponseDto,DomainError>> CreateCompany(CompanyDto request)
        {
            var entity= request.ToEntity();
            if (entity.Name is null || entity.Name == "")
            return Result.Failure<CompanyResponseDto, DomainError>(DomainError.NotFound("CompanyName is empty"));
            entity= await _companyRepository.AddAsync(entity);
            await _companyRepository.SaveAsync();
            var response=CompanyResponseDto.Create(entity);
            return Result.Success<CompanyResponseDto, DomainError>(response);

        }

        public async Task<List<Result<CompanyResponseDto,DomainError>>> GetAllCompanies()
        {
            var data = await _companyRepository.GetAllAsync();
            var response = data.Select(CompanyResponseDto.Create).ToList();
            var resultList = response.Select(company => Result.Success<CompanyResponseDto, DomainError>(company)).ToList();
            return resultList;
        }
    }
}
