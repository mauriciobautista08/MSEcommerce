using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Queries.DTO
{
    public class ProductInStockDTO
    {
        public int ProductInStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
