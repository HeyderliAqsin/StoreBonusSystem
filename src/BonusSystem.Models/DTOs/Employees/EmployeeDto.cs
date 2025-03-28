using BonusSystem.Models.Entities;

namespace BonusSystem.Models.DTOs.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid StoreId { get; set; }
        public decimal Salary { get; set; }
        public Guid PositionId { get; set; }


        public Employee ToEntity()
        {
            return new Employee
            {
                Id = Id,
                Name = FullName,
                BaseSalary = Salary,
            };
        }
    }
}
