using DataAccessLayer.Entities.NetMonitoring;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IMonitoringRepository
    {
        public Task<List<Monitoring>> getAllLogs(int minute);
    }
}
