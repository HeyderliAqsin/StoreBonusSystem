using BonusSystem.Core.Repositories;
using BonusSystem.Core.Repositories.Special;
using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
