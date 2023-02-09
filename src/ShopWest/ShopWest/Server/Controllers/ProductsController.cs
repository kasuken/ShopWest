﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWest.Server.Services;

namespace ShopWest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IShopWestService _shopWestService;

        public ProductsController(IShopWestService shopWestService)
        {
            _shopWestService = shopWestService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shopWestService.GetProducts());
        }
    }
}
