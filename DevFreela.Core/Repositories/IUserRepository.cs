using System;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository : IGeralRepository
    {
        Task<User> GetById(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
