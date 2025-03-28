using BonusSystem.Models.Entities;

namespace BonusSystem.Models.DTOs.Companies
{
    public class CompanyDto
    {
        public string CompanyName { get; set; }
        public Company ToEntity()
        {
            return new Company
            {
                Id = Guid.NewGuid(),
                Name = CompanyName
            };
        }
    }
}
