using Microsoft.EntityFrameworkCore;

namespace FABRADE.Models
{
    public class fabradeDBContext:DbContext
    {
        public fabradeDBContext(DbContextOptions<fabradeDBContext> options):base(options)
        {

        }

        public DbSet<fabradeTransaction>? fabradeTransactions { get; set; }
    }
}
