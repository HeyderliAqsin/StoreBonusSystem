using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Core.Repositories.Special
{
    public interface IGradeRepository : IRepository<Grade>
    {
        Task<Result<decimal,DomainError>> CalculateFixedGradeBonusAsync(Grade grade, decimal totalSales);
        Task<Result<decimal, DomainError>> CalculatePercentageGradeBonusAsync(Grade grade, decimal totalSales, int employeeCount);
        Task<Result<decimal, DomainError>> CalculateThresholdGradeBonusAsync(Grade grade, decimal totalSales, int employeeCount);
    }
}
