using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace CustomersAPI.Data
{    
    public class CustomersContext : DbContext
    {
        #region properties

        public DbSet<Customer> customer {get;set;}

        #endregion

        #region ctors
        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {

        }
        #endregion
    }

    public static class CustomersContextFactory
    {
        public static CustomersContext Create(string ConnectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomersContext>();
            optionsBuilder.UseMySQL(ConnectionString);
            
            var Context = new CustomersContext(optionsBuilder.Options);
            Context.Database.EnsureCreated();

            return Context;
        }
    }
}