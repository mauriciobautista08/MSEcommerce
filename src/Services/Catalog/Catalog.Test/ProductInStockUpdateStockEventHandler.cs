using Catalog.Domain;
using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Test.config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Services.EventHandlers.Commands.ProductInStockUpdateCommand;
using static Catalos.Service.Commons.Enums;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlers
    {

        private ILogger<ProductInStockUpdateEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateEventHandler>>().Object;
            }
        }

        [TestMethod]
        public async Task TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                ProductId = productId,
                ProductInStockId = productInStockId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new Services.EventHandlers.ProductInStockUpdateEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItems>()
                {
                    new ProductInStockUpdateItems
                    {
                        ProductId = 1,
                        Stock = 1,
                        Action = ProductInStockAction.Subtract
                    }
                }
            }, new CancellationToken()).Wait();
        }


    }
}
