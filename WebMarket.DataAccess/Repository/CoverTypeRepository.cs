using WebMarket.DataAccess.Repository.IRepository;
using WebMarket.DataAccess.Data;
using WebMarket.Models;

namespace WebMarket.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        public WebMarket_DB WebMarket_DB { get; set; }
        public CoverTypeRepository(WebMarket_DB webMarket_DB) : base(webMarket_DB)
        {
            WebMarket_DB = webMarket_DB;
        }
        public void Update(CoverType coverType)
        {
            WebMarket_DB.CoverTypes.Update(coverType);
        }
    }
}
