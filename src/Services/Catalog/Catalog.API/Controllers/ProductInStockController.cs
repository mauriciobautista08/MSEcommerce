using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    public class ProductInStockController : ControllerBase
    {
        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;

        public ProductInStockController(
            ILogger<ProductInStockController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStock(ProductInStockDelete command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}
