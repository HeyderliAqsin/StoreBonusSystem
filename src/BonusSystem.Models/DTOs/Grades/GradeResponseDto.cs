using BonusSystem.Models.Entities;

namespace BonusSystem.Models.DTOs.Grades
{
    public class GradeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public GradeType Type { get; set; }
        public Guid StoreId { get; set; }
        public Guid PositionId { get; set; }
    }
}
