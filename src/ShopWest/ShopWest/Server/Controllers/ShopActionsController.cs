using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWest.Server.Services;

namespace ShopWest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopActionsController : ControllerBase
    {
        private readonly IShopWestService _shopWestService;

        public ShopActionsController(IShopWestService shopWestService)
        {
            _shopWestService = shopWestService;
        }


    }
}
