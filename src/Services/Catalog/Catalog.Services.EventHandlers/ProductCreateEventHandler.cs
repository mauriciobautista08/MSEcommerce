using Catalog.Domain;
using Catalog.PersistenceDB;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Services.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand> 
    {
        private readonly ApplicationDBContext _context;

        public ProductCreateEventHandler(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task Handle(ProductCreateCommand notifiaction, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = notifiaction.Name,
                Description = notifiaction.Description,
                Price = notifiaction.Price
            });

            await _context.SaveChangesAsync();
        }

    }
}
