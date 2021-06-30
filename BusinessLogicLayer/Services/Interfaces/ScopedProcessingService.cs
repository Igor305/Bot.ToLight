using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly IBotService _botService;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _botService.getStatus();

                executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}
