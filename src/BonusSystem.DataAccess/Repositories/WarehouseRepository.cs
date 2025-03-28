using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
