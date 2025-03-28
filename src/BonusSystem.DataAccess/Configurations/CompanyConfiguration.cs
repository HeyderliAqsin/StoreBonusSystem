using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusSystem.DataAccess.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("uniqueidentifier");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(c => c.Warehouses)
                .WithOne()
                .HasForeignKey("CompanyId")
                .OnDelete(DeleteBehavior.Cascade); 

            builder.ToTable("Companies");
        }
    }
}
