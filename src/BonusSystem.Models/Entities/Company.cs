using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public required string CompanyName { get; set; }
        public List<Warehouse>? Warehouses { get; set; }
    }
}
