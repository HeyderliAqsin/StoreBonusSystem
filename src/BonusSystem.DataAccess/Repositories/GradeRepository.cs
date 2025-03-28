using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private readonly DbSet<Grade> _dbSet;

        public GradeRepository(DbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Grade>();
        }
        public async Task<Result<decimal, DomainError>> CalculateFixedGradeBonusAsync(Grade grade, decimal totalSales)
        {
            if (grade is null)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Grade cannot be null."));
            if (totalSales <= 0)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Total sales must be greater than 0."));
            if (totalSales > grade.Amount)
            {
                return grade.Amount;
            }
            return 0;
        }
        public async Task<Result<decimal, DomainError>> CalculatePercentageGradeBonusAsync(Grade grade, decimal totalSales, int employeeCount)
        {
            if (grade is null)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Grade cannot be null."));
            if (totalSales <= 0)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Total sales must be greater than 0."));
            if (employeeCount <= 0)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Employee count must be greater than 0."));
            if (totalSales > grade.Amount)
            {
                decimal totalBonus = (grade.Percentage / 100) * totalSales;
                return totalBonus;
            }
            return 0;
        }
        public async Task<Result<decimal, DomainError>> CalculateThresholdGradeBonusAsync(Grade grade, decimal totalSales, int employeeCount)
        {
            if (grade is null)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Grade cannot be null."));
            if (totalSales <= 0)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Total sales must be greater than 0."));
            if (employeeCount <= 0)
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest("Employee count must be greater than 0."));
            decimal percentage = 0;

            if (totalSales >= 100000 && totalSales < 200000)
                percentage = 1;
            else if (totalSales >= 200000 && totalSales < 300000)
                percentage = 2.5m;
            else if (totalSales >= 300000)
                percentage = 3.4m;

            if (percentage > 0)
            {
                decimal totalBonus = (percentage / 100) * totalSales;
                return totalBonus / employeeCount;
            }
            return 0;
        }

    }
}
