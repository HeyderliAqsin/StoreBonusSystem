using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class GradeThreshold: BaseEntity<Guid>
    {
        public decimal MinSales { get; set; }
        public decimal MaxSales { get; set; }
        public decimal Percentage { get; set; }
        public Guid GradeId { get; set; } 
        public Grade Grade { get; set; }
    }
}
