using System;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDto>> GetAll()
        {
            return await _dbContext.Skills
                .Select(s => 
                    new SkillDto()
                    {
                        Id = s.Id,
                        Description = s.Description
                    }
                )
                .ToListAsync();
        }
    }
}
