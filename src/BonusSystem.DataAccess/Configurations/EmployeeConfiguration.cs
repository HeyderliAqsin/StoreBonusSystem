using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusSystem.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.BaseSalary)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
         

            builder.HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey("PositionId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CurrentStore)
                .WithMany(s => s.Employees)
                .HasForeignKey("StoreId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Employees");
        }
    }
}
