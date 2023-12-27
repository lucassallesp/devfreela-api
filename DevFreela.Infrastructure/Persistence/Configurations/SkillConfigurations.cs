using System;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasKey(s => s.Id);
        }
    }
}
