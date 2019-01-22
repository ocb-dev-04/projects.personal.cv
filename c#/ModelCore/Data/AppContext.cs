using Microsoft.EntityFrameworkCore;
using ModelCore.Entities;

namespace ModelCore.Data
{
    public class AppContext : DbContext
    {
        #region Construct

        public AppContext(DbContextOptions<AppContext> options):base(options)
        {}

        #endregion

        #region DbSet's

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        #endregion
    }
}
