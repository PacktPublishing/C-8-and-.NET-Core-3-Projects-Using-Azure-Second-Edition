using SalesOrder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.SalesOrderCreation
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ISalesOrderContext _salesOrderContext;

        public SalesOrderRepository(ISalesOrderContext salesOrderContext)
        {
            _salesOrderContext = salesOrderContext;
        }

        public void Create(SalesOrderEntity salesOrderEntity)
        {
            _salesOrderContext.Add(salesOrderEntity);
            _salesOrderContext.SaveChanges();
        }
    }
}
