using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IBotService _botService;

        public StatusController(IBotService botService)
        {
            _botService = botService;
        }

        [HttpGet]
        public StatusShopResponseModel Bot()
        {
            StatusShopResponseModel statusShopResponseModel = _botService.getStatusBot();

            return statusShopResponseModel;
        }
    }
}
