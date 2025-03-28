using BonusSystem.Models.DTOs.Employees;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Core.Services
{
    public interface IEmployeeService
    {
        Task<Result<EmployeeResponseDto,DomainError>> CreateEmployee(EmployeeDto request);
        Task<Result<EmployeeResponseDto,DomainError>> GetEmployeeById(Guid id);
        Task<List<Result<EmployeeResponseDto,DomainError>>> GetAllEmployees();
        Task<Result<EmployeeResponseDto,DomainError>> UpdateEmployee(EmployeeDto request);
        Task DeleteEmployee(Guid id);

    }
}
