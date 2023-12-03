using LifeInFocus.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeInFocus.Data.Mappings
{
    public class GoalCategoryMapping : IEntityTypeConfiguration<GoalCategory>
    {
        public void Configure(EntityTypeBuilder<GoalCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            builder.Property(x => x.RegistrationDate)
              .IsRequired()
              .HasColumnType("datetime")
              .HasColumnName("RegistrationDate");

            builder.Property(x => x.IsDeleted)
              .IsRequired()
              .HasColumnType("bool")
              .HasColumnName("IsDeleted");

            // 1 : N => GoalCategory : Goals
            builder.HasMany(gc => gc.Goals)
                .WithOne(g => g.Category)
                .HasForeignKey(g => g.CategoryId);
        }
    }
}
