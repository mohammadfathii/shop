using WebMarket.Models;
using System.Linq.Expressions;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICategoryService{
        public IEnumerable<Category> GetAll();
        public Category GetFirstOrDefault(Expression<Func<Category,bool>> filter);
        public void Add(Category category);
        public void Update(Category category);
        public void Remove(Category category);
        public void RemoveRange(IEnumerable<Category> categories);
        public void Save();
    }
}