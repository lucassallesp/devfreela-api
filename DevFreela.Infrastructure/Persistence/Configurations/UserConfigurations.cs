using System;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(us => us.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
