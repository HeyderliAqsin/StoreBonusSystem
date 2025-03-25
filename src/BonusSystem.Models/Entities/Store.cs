using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Store : BaseEntity<Guid>
    {
        public required string StoreName { get; set; }
        public Warehouse? ParentWareHouse { get; set; }
        public List<Employee>? Employees { get; set; }
        public Grade? Grade { get; set; }
    }
}
