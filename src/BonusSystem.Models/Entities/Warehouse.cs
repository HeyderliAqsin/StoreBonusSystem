using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Warehouse : BaseEntity<Guid>
    {
        public required string WarehouseName { get; set; }
        public Company? ParentCompany { get; set; }
        public List<Store>? Stores { get; set; }
    }
}
