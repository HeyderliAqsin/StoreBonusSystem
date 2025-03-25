using BonusSystem.Models.Entities;

namespace BonusSystem.Core.Repositories.Special
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByStore(string store);
        IQueryable<Employee> GetEmployeesByPosition(string position);
    }
}
