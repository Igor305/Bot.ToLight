using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.NetMonitoring
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly NetMonitoringContext _netMonitoringContext;

        public MonitoringRepository(NetMonitoringContext netMonitoringContext)
        {
            _netMonitoringContext = netMonitoringContext;
        }

        public async Task<List<Monitoring>> getAllLogs(int minute)
        {
            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Hour == DateTime.Now.Hour &&
            x.LogTime.Value.Date == DateTime.Now.Date && x.LogTime.Value.Minute >= DateTime.Now.Minute - minute && x.LogTime.Value.Minute <= DateTime.Now.Minute).OrderBy(x =>x.Stock).ToListAsync();

            return monitorings;            
        }
    }
}
