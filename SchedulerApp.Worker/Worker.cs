using Cronos;
using SchedulerApp.Worker.Services;

namespace SchedulerApp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly int _machineId;
        private readonly string LocationID;
        private readonly CronExpression _cron;


        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IConfiguration config)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _machineId = config.GetValue<int>("MachineID");
            LocationID = config.GetValue<string>("LocationID") ?? "49410046-B4C0-430C-3F9F-08DD99ACEA16";
            var cronExpression = config["Schedule:Cron"];
            _cron = CronExpression.Parse(cronExpression);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var next = _cron.GetNextOccurrence(DateTime.UtcNow);
                if (!next.HasValue) continue;
                var delay = next.Value - DateTime.UtcNow;
                _logger.LogInformation("Next run scheduled at: {Time}", next.Value);
                if (delay > TimeSpan.Zero)
                    await Task.Delay(delay, stoppingToken);
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
                    var fileService = scope.ServiceProvider.GetRequiredService<IFileService>();
                    var ftpService = scope.ServiceProvider.GetRequiredService<IFtpService>();
                    var currentDate = next ?? DateTime.UtcNow;
                    var data = await dataService.GetSuntecDataAsync(currentDate, _machineId, LocationID);
                    var fileName = await fileService.GenerateFileAsync(data, currentDate, _machineId);
                    var status = await ftpService.UploadFileAsync(fileName);
                    if(status)
                        await dataService.UpdateLog(fileName, _machineId, currentDate, currentDate, data.FirstOrDefault()?.BatchId ?? 1);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }
    }
}
