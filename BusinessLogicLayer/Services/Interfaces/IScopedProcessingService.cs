using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public  interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
