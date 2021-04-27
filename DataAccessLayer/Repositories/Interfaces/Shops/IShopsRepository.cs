using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopsRepository
    {
        public Task<List<Shop>> getAllShops();
    }
}
