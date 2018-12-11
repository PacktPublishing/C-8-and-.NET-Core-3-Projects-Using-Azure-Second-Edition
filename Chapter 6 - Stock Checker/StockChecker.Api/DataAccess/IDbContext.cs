using Microsoft.EntityFrameworkCore;
using StockChecker.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockChecker.Api.DataAccess
{
    public interface IDbContext
    {
        DbSet<Product> Products { get; set; }

        int SaveChanges();
    }
}
