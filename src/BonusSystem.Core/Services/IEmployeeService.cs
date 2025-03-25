using BonusSystem.Models.DTOs.Employees.Create;
using BonusSystem.Models.DTOs.Employees.GetById;

namespace BonusSystem.Core.Services
{
    public interface IEmployeeService
    {
        public EmployeeCreateResponseDto CreateEmployee(EmployeeCreateDto request);
        public EmployeeGetByIdResponseDto GetById(int id);
    }
}
