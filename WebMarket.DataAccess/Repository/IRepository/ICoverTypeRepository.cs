using WebMarket.Models;

namespace WebMarket.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        public void Update(CoverType coverType);
    }
}
