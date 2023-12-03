using LifeInFocus.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeInFocus.Data.Mappings
{
    public class GoalMapping : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            builder.Property(x => x.Deadline)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("Deadline");

            builder.Property(x => x.Motivation)
                .IsRequired(false)
                .HasColumnType("varchar(200)")
                .HasColumnName("Motivation");

            builder.Property(x => x.Reward)
                .IsRequired(false)
                .HasColumnType("varchar(200)")
                .HasColumnName("Reward");

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Priority");

            builder.Property(x => x.RegistrationDate)
               .IsRequired()
               .HasColumnType("datetime")
               .HasColumnName("RegistrationDate");

            builder.Property(x => x.IsDeleted)
              .IsRequired()
              .HasColumnType("bit")
              .HasColumnName("IsDeleted");

        }
    }
}
