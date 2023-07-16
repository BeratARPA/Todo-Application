using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASP.NETCoreUI.Data
{
    public class GenericRepository<T> where T : class
    {
        private readonly SQLContext _dbContext;

        public GenericRepository(SQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _dbContext.Set<T>().AsNoTracking().ToList()
                : _dbContext.Set<T>().Where(filter).ToList();
        }
    }
}
