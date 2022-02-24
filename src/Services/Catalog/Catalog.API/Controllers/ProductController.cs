﻿using Catalog.Service.Queries;
using Catalog.Service.Queries.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Catalog.Service.Queries.ProductQueryService;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductQueryService  _productQueryService;
        public ProductController(ILogger<ProductController> logger, IProductQueryService productQueryService)
        {
            _logger = logger;
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDTO>> GetAll(int page = 1, int take = 10 , string ids = null)
        {
            IEnumerable<int> products = null;
            if(!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

    }
}