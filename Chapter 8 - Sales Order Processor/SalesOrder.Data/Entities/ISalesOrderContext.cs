using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SalesOrder.Data.Entities
{
    public interface ISalesOrderContext
    {
        DbSet<SalesOrderEntity> SalesOrders { get; set; }

        EntityEntry Add(object entity);                

        int SaveChanges();
    }
}