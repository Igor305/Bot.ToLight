using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IBotService _botService;

        public BotController(IBotService botService)
        {
            _botService = botService;
        }

        [HttpGet]
        public async Task<StatusShopResponseModel> Bot()
        {
            StatusShopResponseModel statusShopResponseModel = await _botService.startBot();

            return statusShopResponseModel;
        }
    }
}
