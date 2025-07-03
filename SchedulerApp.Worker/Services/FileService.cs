using SchedulerApp.Worker.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;

    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
    }

    public async Task<string> GenerateFileAsync(IEnumerable<SuntecDto> data, DateTime date, int machineId)
    {
        var filePath = Path.Combine(Path.GetTempPath(), $"{machineId}_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

        using var writer = new StreamWriter(filePath);
        foreach (var item in data)
        {
            var line = $"{item.MachineId}|{item.BatchId}|{item.Date}|{item.Hour}|{item.Receipt}|{item.GTOSales:F2}|{item.GST:F2}|{item.Discount:F2}|{item.Pax}";
            await writer.WriteLineAsync(line);
            _logger.LogInformation(line);
        }
        await writer.FlushAsync();
        return filePath;
    }
}
