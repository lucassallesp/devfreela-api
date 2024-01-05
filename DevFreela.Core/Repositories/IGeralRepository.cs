namespace DevFreela.Core.Repositories
{
    public interface IGeralRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        T GetById<T>(int id) where T: class;
        Task<bool> SaveChangesAsync();
    }
}