using BonusSystem.Models.Entities;
using CSharpFunctionalExtensions;

namespace BonusSystem.Core.Repositories.Special
{
    public interface ISalesRepository : IRepository<Store>
    {
        Task<Result<decimal,DomainError>> GetSalesByStoreAsync(Guid id, DateTime month);
    }
}
