using BonusSystem.Models.Common;
namespace BonusSystem.Models.Entities
{
    public class Store : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public decimal Sales { get; set; }
        public Guid GradeId { get; set; }
        public Grade StoreGrade { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
