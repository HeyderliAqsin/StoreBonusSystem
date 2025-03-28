using BonusSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusSystem.DataAccess.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnType("uniqueidentifier");

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.Type)
                .IsRequired();

            builder.Property(g => g.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(g => g.Percentage)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.HasMany(g => g.Thresholds)  
                .WithOne(gt => gt.Grade)         
                .HasForeignKey(gt => gt.GradeId) 
                .OnDelete(DeleteBehavior.Cascade); 

            builder.ToTable("Grades");
        }
    }
}
