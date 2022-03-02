using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Catalog.Services.EventHandlers.Commands.ProductInStockUpdateCommand;
using static Catalos.Service.Commons.Enums;

namespace Catalog.Services.EventHandlers.Commands
{
    public class ProductInStockUpdateCommand : INotification
    {

        public IEnumerable<ProductInStockUpdateItems> Items { get; set; } = new List<ProductInStockUpdateItems>();



        public class ProductInStockUpdateItems
        {

            public int ProductId { get; set; }
            public int Stock { get; set; }
            public ProductInStockAction Action { get; set; }
        }

    }
}
