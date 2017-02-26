using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Data
{
    public class CustomersContext : DbContext
    {
        #region properties

        public DbSet<Customer> Customers {get;set;}

        #endregion

        #region ctors
        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {

        }
        #endregion
    }
}