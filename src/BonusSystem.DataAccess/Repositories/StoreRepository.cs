using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
