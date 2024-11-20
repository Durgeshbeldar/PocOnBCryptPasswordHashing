using Microsoft.EntityFrameworkCore;
using PasswordHasher.Data;

namespace PasswordHasher.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PasswordHasherContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(PasswordHasherContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public IQueryable<T> Get()
        {
           return _dbSet.AsQueryable();
        }
    }
}
