using BonusSystem.Models.Entities;

namespace BonusSystem.Models.DTOs.Companies
{
    public class CompanyResponseDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }

        public static CompanyResponseDto Create(Company company)
        {
            return new CompanyResponseDto
            {
                Id = company.Id,
                CompanyName = company.Name
            };
        }
    }
}
