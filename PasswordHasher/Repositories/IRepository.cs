namespace PasswordHasher.Repositories
{
    public interface IRepository<T>
    {
        public T Add(T entity);
        public IQueryable<T> Get();
    }
}
