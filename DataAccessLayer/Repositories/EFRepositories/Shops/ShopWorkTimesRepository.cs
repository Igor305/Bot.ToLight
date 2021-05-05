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
        public async Task<List<ShopWorkTime>> getTimeToDay()
        {
            ShopsContext shopsContext = new ShopsContext();

            List<ShopWorkTime> shopWorkTimes = await shopsContext.ShopWorkTimes.OrderBy(x => x.Id).ToListAsync();

            return shopWorkTimes;
        }
    }
}
