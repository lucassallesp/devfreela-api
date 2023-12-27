using System;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .HasKey(us => us.Id);
        }
    }
}
