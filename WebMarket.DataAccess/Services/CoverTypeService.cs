using System.Linq.Expressions;
using WebMarket.DataAccess.Data;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CoverTypeService{
        public WebMarket_DB WebMarket_DB;
        public CoverTypeService(WebMarket_DB webMarket_DB){
            WebMarket_DB = webMarket_DB;
        }

        public IEnumerable<CoverType> GetAll(){
            var CoverTypes = WebMarket_DB.CoverTypes;
            return CoverTypes;
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType,bool>> filter){
            // !! use IQuerable Type for using where method to search
            IQueryable<CoverType> coverType = WebMarket_DB.CoverTypes;
            coverType = coverType.Where(filter);
            return coverType.FirstOrDefault();
        }

        public void Add(CoverType coverType){
            WebMarket_DB.CoverTypes.Add(coverType);
        }

        public void Update(CoverType coverType){
            WebMarket_DB.CoverTypes.Update(coverType);
        }

        public void Remove(CoverType coverType){
            WebMarket_DB.Remove(coverType);
        }

        public void RemoveRange(ICollection<CoverType> coverTypes){
            WebMarket_DB.RemoveRange(coverTypes);
        }

        public void Save(){
            WebMarket_DB.SaveChanges();
        }

    }
}