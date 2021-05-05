using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IBotService _botService;

        public BotController(IBotService botService, IServiceScopeFactory serviceScopeFactory)
        {
            _botService = botService;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public async Task<List<StatusShopModel>> Bot()
        {
            List<StatusShopModel> statusShopModels = await _botService.startBot();
            return statusShopModels;
        }
    }
}
