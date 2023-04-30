using WebMarket.Models;
using System.Linq.Expressions;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICoverTypeService{
        public IEnumerable<CoverType> GetAll();
        public CoverType GetFirstOrDefault(Expression<Func<CoverType,bool>> filter);
        public void Add(CoverType coverType);
        public void Update(CoverType coverType);
        public void Remove(CoverType coverType);
        public void RemoveRange(IEnumerable<CoverType> coverTypes);
        public void Save();
    }
}