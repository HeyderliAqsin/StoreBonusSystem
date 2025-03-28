using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Warehouse : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
