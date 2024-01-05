using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository : GeralRepository, IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(DevFreelaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id && p.Status != ProjectStatusEnum.Cancelled);

            return project;
        }
    }
}
