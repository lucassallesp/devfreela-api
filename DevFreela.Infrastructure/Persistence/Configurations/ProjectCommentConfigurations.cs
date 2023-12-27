using System;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
