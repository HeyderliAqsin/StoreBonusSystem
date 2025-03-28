using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Core.Services
{
    public interface ISalaryService
    {
        Task<Result<decimal,DomainError>> CalculateSalaryAsync(Guid employeeId, DateTime startDate, DateTime endDate);
    }
}
