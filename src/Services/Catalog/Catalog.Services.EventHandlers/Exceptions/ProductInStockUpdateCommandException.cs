using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Services.EventHandlers.Exceptions
{
    public class ProductInStockUpdateCommandException : Exception
    {
        public ProductInStockUpdateCommandException(string message) : base(message) { }
    }
}
