using WebMarket.Models;
using System.Linq.Expressions;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IProductService{
        
        public IEnumerable<Product> GetAll();
        public Product GetFirstOrDefault(Expression<Func<Product,bool>> filter);
        public void Add(Product coverType);
        public void Update(Product coverType);
        public void Remove(Product coverType);
        public void RemoveRange(IEnumerable<Product> coverTypes);
        public void Save();
    }
}