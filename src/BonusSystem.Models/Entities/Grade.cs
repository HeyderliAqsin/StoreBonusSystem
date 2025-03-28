using BonusSystem.Models.Common;

namespace BonusSystem.Models.Entities
{
    public class Grade: BaseEntity<Guid>
    {
        public string Name { get; set; }
        public GradeType Type { get; set; }
        public decimal Amount { get; set; } 
        public decimal Percentage { get; set; }
        public List<GradeThreshold> Thresholds { get; set; }
    }
}
