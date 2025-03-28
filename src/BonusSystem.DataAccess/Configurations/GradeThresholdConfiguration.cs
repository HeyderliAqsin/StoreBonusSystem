using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusSystem.DataAccess.Configurations
{
    public class GradeThresholdConfiguration : IEntityTypeConfiguration<GradeThreshold>
    {
        public void Configure(EntityTypeBuilder<GradeThreshold> builder)
        {

            builder.HasKey(gt => gt.Id);
            builder.Property(gt => gt.Id)
                .HasColumnType("uniqueidentifier");

            builder.Property(gt => gt.MinSales)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(gt => gt.MaxSales)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(gt => gt.Percentage)
                .HasColumnType("decimal(5,2)") 
                .IsRequired();

            builder.HasIndex(gt => new { gt.MinSales, gt.MaxSales });
            builder.ToTable("GradeThresholds");
        }
    }
}
