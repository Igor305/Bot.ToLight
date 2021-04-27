using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.Shops;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopsRepository : IShopsRepository
    {
        private readonly ShopsContext _shopsContext;

        public ShopsRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<List<Shop>> getAllShops()
        {
            List<Shop> shops = await _shopsContext.Shops.Where(x => x.StatusId == 25).OrderBy(x =>x.ShopNumber).ToListAsync();
            return shops;
        }
    }
}
