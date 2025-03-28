using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusSystem.DataAccess.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnType("uniqueidentifier");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Sales)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.HasOne(s => s.Warehouse)
                .WithMany(w => w.Stores)
                .HasForeignKey("WarehouseId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.StoreGrade)
                .WithMany()
                .HasForeignKey("GradeId")
                .IsRequired(false);

            builder.HasMany(s => s.Employees)
                .WithOne(e => e.CurrentStore)
                .HasForeignKey("StoreId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Stores");
        }
    }
}
