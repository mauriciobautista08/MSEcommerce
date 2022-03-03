using Catalog.Domain;
using Catalog.PersistenceDB;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Services.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalos.Service.Commons.Enums;

namespace Catalog.Services.EventHandlers
{
    public class ProductInStockUpdateEventHandler : INotificationHandler<ProductInStockUpdateCommand>
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<ProductInStockUpdateEventHandler> _logger;

        public ProductInStockUpdateEventHandler(ApplicationDBContext context, ILogger<ProductInStockUpdateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" --- Función de actualizar producto en stock inicializado --- ");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation(" --- Devuelve datos de la BD --- ");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Subtract)
                {

                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($" ---- el producto  {entry.ProductId}  no cuenta con suficiente stock");
                        throw new ProductInStockUpdateCommandException($"Producto {entry.ProductId} no cuenta con suficiente stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogInformation($" --- El stock del producto {entry.ProductId} ha substraido exitosamente y su nuevo valor es {entry.Stock}");
                }
                else
                {
                    if(entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        _logger.LogInformation($" --- Nuevo registro de stocj fue creado, porque {entry.ProductId} no existía en la base de datos anteriormente. --- ");

                        await _context.AddAsync(entry);
                    }
                    _logger.LogInformation($" --- Nuevo stock agregado para el producto {entry.ProductId} --- ");
                    entry.Stock += item.Stock;
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}
