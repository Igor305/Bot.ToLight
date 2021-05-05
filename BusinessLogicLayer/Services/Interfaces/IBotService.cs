using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBotService
    {
        public Task<List<StatusShopModel>> startBot();
    }
}
