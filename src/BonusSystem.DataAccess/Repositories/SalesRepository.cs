using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class SalesRepository : Repository<Store>, ISalesRepository
    {
        private readonly DbSet<Store> _dbSet;
        public SalesRepository(DbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Store>();
        }

        public Task<Result<decimal, DomainError>> GetSalesByStoreAsync(Guid id, DateTime month)
        {
            throw new NotImplementedException();
        }

        //    public async Task<Result<decimal, DomainError>> GetSalesByStoreAsync(Guid id, DateTime month)
        //    {
        //        if (id == Guid.Empty)
        //            return Result.Failure<decimal, DomainError>(DomainError.NotFound());

        //        try
        //        {
        //            var sales = await _dbSet
        //                .Where(m => m.StoreId == id && m.SalesDate.Month == month.Month && m.SalesDate.Year == month.Year)
        //                .SumAsync(m => m.TotalSales);
        //            if (sales == 0)
        //                return Result.Failure<decimal, DomainError>(DomainError.NotFound("No sales data found for this store in the given month."));
        //            return Result.Success<decimal, DomainError>(sales);

        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            return Result.Failure<decimal, DomainError>(DomainError.InternalError($"Error in database operation: {ex.Message}"));
        //        }
        //        catch (Exception ex)
        //        {
        //            return Result.Failure<decimal, DomainError>(DomainError.Unexpected($"An unexpected error occurred: {ex.Message}"));
        //        }
        //    //}
        //}
    }
}
