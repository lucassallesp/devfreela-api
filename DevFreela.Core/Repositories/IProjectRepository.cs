using System;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository : IGeralRepository
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
    }
}
