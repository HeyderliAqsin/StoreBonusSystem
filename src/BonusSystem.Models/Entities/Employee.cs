using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Employee : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid PositionId { get; set; }
        public Position Position { get; set; } 
        public decimal BaseSalary { get; set; }
        public Guid StoreId { get; set; }
        public Store CurrentStore { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
