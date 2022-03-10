using Catalog.Domain;
using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Services.EventHandlers.Exceptions;
using Catalog.Test.config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateCommandException))]
        public void TryToSubstractWhenProductHasntStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 2;
            var productId = 2;


            context.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            
            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            try
            {

                handler.Handle(new ProductInStockUpdateCommand
                {
                    Items = new List<ProductInStockUpdateItems>
                {
                    new ProductInStockUpdateItems
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Subtract
                    }
                }
                }, new CancellationToken()).Wait();
            }catch (AggregateException ae)
            {
                if(ae.GetBaseException() is ProductInStockUpdateCommandException)
                {
                    throw new ProductInStockUpdateCommandException(ae.InnerException?.Message);
                }
            }
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            context.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItems>()
                {
                    new ProductInStockUpdateItems
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            Assert.AreEqual(context.Stocks.First(x => x.ProductInStockId == productInStockId).Stock, 3);

        }

        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();
            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            var productId = 4;


            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItems>
                {
                    new ProductInStockUpdateItems
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            Assert.AreEqual(context.Stocks.First(x => x.ProductId == productId).Stock, 2);
        }

    }
}
