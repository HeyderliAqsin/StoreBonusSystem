using BonusSystem.Models.Entities;

namespace BonusSystem.Models.DTOs.Employees
{
    public class EmployeeResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid StoreId { get; set; }
        public decimal BaseSalary { get; set; }
        public Guid PositionId { get; set; }

        public static EmployeeResponseDto Create(Employee employee)
        {
            return new EmployeeResponseDto
            {
                Id = employee.Id,
                FullName = employee.Name,
                BaseSalary = employee.BaseSalary
            };
        }
    }
}
