using Microsoft.EntityFrameworkCore;
using Review.Model;

namespace Review
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
