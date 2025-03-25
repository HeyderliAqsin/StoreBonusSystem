using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Employee : BaseEntity<Guid>
    {
        public required string EmployeeName { get; set; }
        public Guid StoreId { get; set; }
        public Guid PositionId { get; set; }
        public virtual Store? Store { get; set; }
        public virtual Position? Position { get; set; }
        public List<Grade>? Grades { get; set; }
    }
}
