using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Models
{
    public class SalesOrder
    {
        public Guid Reference { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
