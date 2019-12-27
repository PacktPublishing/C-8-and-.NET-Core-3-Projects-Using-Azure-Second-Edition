using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.Entities
{
    class SalesOrderDesignContext
    {
        public class SalesOrderContextFactory : IDesignTimeDbContextFactory<SalesOrderContext>
        {
            public SalesOrderContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SalesOrderContext>();
                optionsBuilder.UseSqlServer(@"Server=tcp:netcodeprojects.database.windows.net,1433;Initial Catalog=SalesOrders;Persist Security Info=False;User ID=netcodeadmin;Password=grhate253!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                return new SalesOrderContext(optionsBuilder.Options);
            }
        }
    }
}
