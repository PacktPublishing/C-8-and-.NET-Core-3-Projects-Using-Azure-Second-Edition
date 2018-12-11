using Microsoft.EntityFrameworkCore;
using StockChecker.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChecker.Api.DataAccess
{
    public class StockContext : DbContext, IDbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
