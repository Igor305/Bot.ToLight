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
        public async Task<List<Monitoring>> getAllLogs(int minute)
        {
            NetMonitoringContext netMonitoringContext = new NetMonitoringContext();

            List<Monitoring> monitorings = await netMonitoringContext.Monitorings.Where(x =>
            x.LogTime.Value >= DateTime.Now.AddMinutes(-minute)).OrderBy(x =>x.Stock).ToListAsync();

            return monitorings;            
        }
    }
}
