using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Services.EventHandlers.Commands
{
    public class ProductInStockDelete : INotification
    {
        public int Id { get; set; }

    }
}
