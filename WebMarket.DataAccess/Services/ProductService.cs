using WebMarket.Models;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using System.Linq.Expressions;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService{
        public WebMarket_DB WebMarket_DB;
        public ProductService(WebMarket_DB webMarket_DB){
            WebMarket_DB = webMarket_DB;
        }

        public IEnumerable<Product> GetAll(){
            IEnumerable<Product> Products = WebMarket_DB.Products;
            return Products;
        }

        public Product GetFirstOrDefault(Expression<Func<Product,bool>> filter){
            IQueryable<Product> Product = WebMarket_DB.Products;
            Product = Product.Where(filter);
            return Product.FirstOrDefault();
        }

        public void Add(Product Product){
            WebMarket_DB.Products.Add(Product);
        }

        public void Update(Product Product){
            WebMarket_DB.Products.Update(Product);
        }

        public void Remove(Product Product){
            WebMarket_DB.Products.Remove(Product);
        }

        public void RemoveRange(IEnumerable<Product> Products){
            WebMarket_DB.Products.RemoveRange(Products);
        }

        public void Save(){
            WebMarket_DB.SaveChanges();
        }

    }
}