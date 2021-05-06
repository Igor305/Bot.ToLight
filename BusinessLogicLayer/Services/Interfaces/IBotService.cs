using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBotService
    {
        public Task<StatusShopResponseModel> startBot();
    }
}
