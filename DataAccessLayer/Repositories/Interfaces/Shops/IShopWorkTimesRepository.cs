using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopWorkTimesRepository
    {
        public Task<List<ShopWorkTime>> getTimeToDay();
    }
}
