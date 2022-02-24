using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Queries.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ProductInStockDTO Stock { get; set; }
    }
}
