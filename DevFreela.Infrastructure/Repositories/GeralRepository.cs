using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class GeralRepository : IGeralRepository
    {
        private readonly DevFreelaDbContext _context;

        public GeralRepository(DevFreelaDbContext context)
        {   
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Find<T>(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}