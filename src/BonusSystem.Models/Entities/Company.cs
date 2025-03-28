using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}
