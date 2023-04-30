using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DataAccess.Data
{
    public class WebMarket_DB : DbContext
    {
        public WebMarket_DB(DbContextOptions<WebMarket_DB> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
    }
}
