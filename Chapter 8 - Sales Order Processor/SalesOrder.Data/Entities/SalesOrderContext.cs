using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.Entities
{
    public class SalesOrderContext : DbContext, ISalesOrderContext
    {
        public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options)
        {

        }

        public DbSet<SalesOrderEntity> SalesOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:netcodeprojects.database.windows.net,1433;Initial Catalog=SalesOrders;Persist Security Info=False;User ID=netcodeadmin;Password=grhate253!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

    }
}
