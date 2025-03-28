using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
