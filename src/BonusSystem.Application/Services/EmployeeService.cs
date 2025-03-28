using BonusSystem.Core.Extensions;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Core.Services;
using BonusSystem.Models.DTOs.Employees;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        public async Task<Result<EmployeeResponseDto,DomainError>> CreateEmployee(EmployeeDto request)
        {
            var entity = request.ToEntity();
            if(entity is null)
            return Result.Failure<EmployeeResponseDto, DomainError>(DomainError.NotFound());
            entity = await _employeeRepository.AddAsync(entity);
             await _employeeRepository.SaveAsync();

            var response = EmployeeResponseDto.Create(entity);
            return Result.Success<EmployeeResponseDto,DomainError>(response);
        }
        public async Task<Result<EmployeeResponseDto, DomainError>> GetEmployeeById(Guid id)
        {
            var entity= await _employeeRepository.GetFirstAsync(m => m.Id == id);
            var response = EmployeeResponseDto.Create(entity);
            return response;
        }
        public async Task DeleteEmployee(Guid id)
        {
            var entity = await _employeeRepository.GetFirstAsync(m => m.Id == id);
            await _employeeRepository.DeleteAsync(entity);
            await _employeeRepository.SaveAsync();
        }
        public async Task<List<Result<EmployeeResponseDto,DomainError>>> GetAllEmployees()
        {
            var data= await _employeeRepository.GetAllAsync();
            var response = data.Select(EmployeeResponseDto.Create).ToList();
            var resultList = response.Select(employee => Result.Success<EmployeeResponseDto, DomainError>(employee)).ToList();

            return resultList;
        }
        public async Task<Result<EmployeeResponseDto, DomainError>> UpdateEmployee(EmployeeDto request)
        {
            var entity = await _employeeRepository.GetFirstAsync(m => m.Id == request.Id);

            await _employeeRepository.EditAsync(entity, entry =>
            {
                entry.SetValue(m => m.Name, request.FullName);
                entry.SetValue(m => m.BaseSalary, request.Salary);
            });
            await _employeeRepository.SaveAsync();
            return EmployeeResponseDto.Create(entity);
        }
    }
}
