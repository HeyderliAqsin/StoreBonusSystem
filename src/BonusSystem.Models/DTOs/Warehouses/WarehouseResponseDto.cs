namespace BonusSystem.Models.DTOs.Warehouses.Create
{
    public class WarehouseResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
    }
}
