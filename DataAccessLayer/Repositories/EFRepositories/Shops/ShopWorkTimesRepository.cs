using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopWorkTimesRepository : IShopWorkTimesRepository
    {
        private readonly ShopsContext _shopsContext;

        public ShopWorkTimesRepository (ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<ShopWorkTime>> getTimeToDay()
        {
            List<ShopWorkTime> shopWorkTimes = await _shopsContext.ShopWorkTimes.OrderBy(x => x.Id).ToListAsync();

            return shopWorkTimes;
        }
    }
}
