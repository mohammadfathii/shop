using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Repository.IRepository;

namespace WebMarket.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public WebMarket_DB _db { get; set; }
        public DbSet<T> dbSet;
        /* Dependency Injection */
        public Repository(WebMarket_DB db) {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            /* to get all entities in table need to use this commands : */
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T,bool>> filter)
        {
            /* to get entity */
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Add(T entity) {
            this.dbSet.Add(entity);
        }

        public void Remove(T entity) {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.dbSet.RemoveRange(entities);
        }
    }
}
