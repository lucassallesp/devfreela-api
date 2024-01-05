using System;
using DevFreela.Core.DTOs;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository : IGeralRepository
    {
        Task<List<SkillDto>> GetAll(); 
    }
}
