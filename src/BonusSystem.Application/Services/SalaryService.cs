using BonusSystem.Core.Exceptions;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Core.Services;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Application.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IGradeRepository _gradeRepository;

        public SalaryService(IEmployeeRepository employeeRepository, IGradeRepository gradeRepository,
            IStoreRepository storeRepository)
        {
            _employeeRepository = employeeRepository;
            _gradeRepository = gradeRepository;
            _storeRepository = storeRepository;
        }

        public async Task<Result<decimal, DomainError>> CalculateSalaryAsync(Guid employeeId, DateTime transferDate, DateTime endDate)
        {
            try
            {
                var employee = await _employeeRepository.GetFirstAsync(m => m.Id == employeeId);
                if (employee is null)
                {
                    return Result.Failure<decimal, DomainError>(DomainError.NotFound("Employee is not found"));
                }
                int daysWorkedInOldStore = CalculateDaysWorkedInOldStore(employee, transferDate, endDate);
                int daysWorkedInNewStore = CalculateDaysWorkedInNewStore(employee, transferDate, endDate);
                if (daysWorkedInOldStore == 0 && daysWorkedInNewStore == 0)
                {
                    return Result.Failure<decimal, DomainError>(DomainError.NotFound("Employee did not work in this period"));
                }
                int daysInMonth = DateTime.DaysInMonth(transferDate.Year, transferDate.Month);
                decimal dailySalary = employee.BaseSalary / daysInMonth;

                decimal salaryInOldStore = dailySalary * daysWorkedInOldStore;
                decimal salaryInNewStore = dailySalary * daysWorkedInNewStore;
                var totalSalary = salaryInOldStore + salaryInNewStore;

                totalSalary += await CalculateGradeBonus(employee.StoreId);

                return Result.Success<decimal, DomainError>(totalSalary);

            }
            catch (InvalidCodeException exp)
            {
                return Result.Failure<decimal, DomainError>(DomainError.BadRequest(exp.Message));
            }
            catch (NotFoundException exp)
            {
                return Result.Failure<decimal, DomainError>(DomainError.NotFound(exp.Message));
            }
        }

        private int CalculateDaysWorkedInOldStore(Employee employee, DateTime transferDate, DateTime endDate)
        {
            if (employee.CreateDate > transferDate)
            {
                return 0;
            }
            var createDate = employee.CreateDate;
            return (transferDate - createDate).Days + 1;
        }


        private int CalculateDaysWorkedInNewStore(Employee employee, DateTime transferDate, DateTime endDate)
        {
            if (employee.CreateDate > endDate)
            {
                return 0;
            }
            DateTime startWorkDate = transferDate > employee.CreateDate ? transferDate : employee.CreateDate;
            return (endDate - startWorkDate).Days + 1;
        }

        private async Task<decimal> CalculateGradeBonus(Guid storeId)
        {
            decimal bonus = 0;
            var store = await _storeRepository.GetFirstAsync(m => m.Id == storeId);
            var gradeType = await _gradeRepository.GetFirstAsync(g => g.Id == store.GradeId);
            switch (gradeType.Type)
            {
                case GradeType.Fixed:
                    bonus = gradeType.Amount;
                    break;
                case GradeType.Percentage:
                    bonus = (store.Sales * gradeType.Percentage / 100);
                    bonus /= store.Employees.Count;
                    break;
                case GradeType.Threshold:
                    bonus = CalculateThresholdBonus(store.Sales, gradeType.Thresholds);
                    break;
            }

            return bonus;
        }
        private decimal CalculateThresholdBonus(decimal sales, List<GradeThreshold> thresholds)
        {
            if (thresholds == null || thresholds.Count == 0)
            {
                return 0;
            }
            decimal bonus = 0;
            foreach (var threshold in thresholds)
            {
                if (sales >= threshold.MinSales && sales <= threshold.MaxSales)
                {
                    bonus = (sales * threshold.Percentage / 100);
                    break;
                }
            }
            return bonus;
        }

    }
}
