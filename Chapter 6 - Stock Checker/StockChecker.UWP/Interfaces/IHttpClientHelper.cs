using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockChecker.UWP.Interfaces
{
    public interface IHttpStockClientHelper
    {
        Task<int> GetQuantityAsync(int productId);
        Task UpdateQuantityAsync(int productId, int newQuantity);
    }
}
