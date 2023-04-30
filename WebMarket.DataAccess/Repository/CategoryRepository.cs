using WebMarket.DataAccess.Repository.IRepository;
using WebMarket.DataAccess.Data;
using WebMarket.Models;

namespace WebMarket.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public WebMarket_DB BlogDbContext { get; set; }
        public CategoryRepository(WebMarket_DB webMarket_DB) : base(webMarket_DB)
        {
            BlogDbContext = webMarket_DB;
        }
        public void Update(Category category)
        {
            BlogDbContext.Categories.Update(category);
        }
    }
}
