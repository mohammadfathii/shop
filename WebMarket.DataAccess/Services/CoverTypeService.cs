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
            CoverType coverType = WebMarket_DB.CoverTypes.FirstOrDefault(filter);
            return coverType;
        }


    }
}