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
            var connStr = "Server=tcp:routingimport.database.windows.net,1433;Initial Catalog=routing_importer;Persist Security Info=False;User ID=hermestest;Password=routingtest2021!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connStr, b => b.MigrationsAssembly("Checkout.DataMigrations"));

            return new BasketDbContext(optionsBuilder.Options);
        }
    }
}
