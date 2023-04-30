using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Repository.IRepository;

namespace WebMarket.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set;  }
        public ICoverTypeRepository CoverType { get; private set; }
        public WebMarket_DB BlogDbContext { get; set; }
        public UnitOfWork(WebMarket_DB webMarket_DB)
        {
            BlogDbContext = webMarket_DB;
            Category = new CategoryRepository(BlogDbContext);
            CoverType = new CoverTypeRepository(BlogDbContext);
        }
        public void SaveChanges()
        {
            BlogDbContext.SaveChanges();
        }
    }
}
