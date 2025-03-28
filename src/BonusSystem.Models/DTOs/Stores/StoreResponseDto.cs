namespace BonusSystem.Models.DTOs.Stores
{
    public class StoreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid WarehouseId { get; set; }
    }
}
