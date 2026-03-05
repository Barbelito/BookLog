using Infrastructure.Persistence.EFC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFC.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.Property(u => u.ModifiedAt)
                .IsRequired();
        }
    }
}
