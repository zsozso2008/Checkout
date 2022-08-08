using Checkout.DataAccess;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Checkout.DataMigrations
{
    [ExcludeFromCodeCoverage]
    internal class BasketDbContextFactory : IDesignTimeDbContextFactory<BasketDbContext>
    {
        public BasketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BasketDbContext>();
            var connStr = "Data Source=.;Initial Catalog=Checkout;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connStr, b => b.MigrationsAssembly("Checkout.DataMigrations"));

            return new BasketDbContext(optionsBuilder.Options);
        }
    }
}
