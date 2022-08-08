using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Checkout.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.DataAccess
{
    public sealed  class BasketDbContext : DbContext
    {
        public DbSet<Basket> Baschet { get; set; }
        public DbSet<Article> Article { get; set; }

        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {

        }
    }
}
