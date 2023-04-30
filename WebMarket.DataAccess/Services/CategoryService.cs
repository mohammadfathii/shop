using WebMarket.Models;
using WebMarket.DataAccess.Data;
using System.Linq.Expressions;

namespace WebMarket.DataAccess.Services
{
    public class CategoryService{
        public WebMarket_DB WebMarket_DB;
        public CategoryService(WebMarket_DB webMarket_DB){
            WebMarket_DB = webMarket_DB;
        }

        public IEnumerable<Category> GetAll(){
            IEnumerable<Category> categories = WebMarket_DB.Categories;
            return categories;
        }

        public Category GetFirstOrDefault(Expression<Func<Category,bool>> filter){
            IQueryable<Category> category = WebMarket_DB.Categories;
            category = category.Where(filter);
            return category.FirstOrDefault();
        }

        public void Add(Category category){
            WebMarket_DB.Categories.Add(category);
        }

        public void Update(Category category){
            WebMarket_DB.Categories.Update(category);
        }

        public void Remove(Category category){
            WebMarket_DB.Categories.Remove(category);
        }

        public void RemoveRange(IEnumerable<Category> categories){
            WebMarket_DB.Categories.RemoveRange(categories);
        }

        public void Save(){
            WebMarket_DB.SaveChanges();
        }

    }
}