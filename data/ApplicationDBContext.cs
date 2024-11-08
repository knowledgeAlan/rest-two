

using Microsoft.EntityFrameworkCore;
using rest_two.Models;


namespace rest_two.data
{
    
    public class ApplicationDBContext : DbContext
    {
         public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Stock> Stocks{ get; set; }

        public DbSet<Comment> Comments{ get; set; }
    }
}