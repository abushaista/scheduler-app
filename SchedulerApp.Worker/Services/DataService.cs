using Microsoft.EntityFrameworkCore;
using SchedulerApp.Worker.DTOs;
using SchedulerApp.Worker.Models;
using SchedulerApp.Worker.Persistent;
using SchedulerApp.Worker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public class DataService : IDataService
{

    private readonly ILogger<DataService> _logger;
    private readonly IBatchRepository _batchRepository;
    private readonly IDataRepository _dataRepository;

    public DataService(ILogger<DataService> logger, IBatchRepository batchRepository, IDataRepository dataRepository)
    {
        _logger = logger;
        _batchRepository = batchRepository;
        _dataRepository = dataRepository;
    }

    public async Task<IEnumerable<SuntecDto>> GetSuntecDataAsync(DateTime date, int machineId, string locationId)
    {
        var data = new List<SuntecDto>();
        try
        {
            var batchId = await _batchRepository.GetCurrentBatchId(machineId, date);
            var HourlyMaster = new List<HourData>();
            for (int i = 0; i < 24; i++)
            {
                var hourString = $"{i:D2}59";
                HourlyMaster.Add(new HourData { Hour = i, BatchId= batchId, HourString = hourString, MachineId = machineId, Pax = 0 });
            }
            var hourlyOrders = await _dataRepository.GetHourlyOrderByDate(date, machineId, locationId);
            var intDate = int.Parse(date.ToString("ddMMyyyy"));

            var suntecData = HourlyMaster.GroupJoin(hourlyOrders, 
                h => h.Hour, 
                o => o.Hour, 
                (h, o) =>
                {
                    var order = o.FirstOrDefault();
                    return
                    new SuntecDto
                    {
                        MachineId = h.MachineId,
                        BatchId = h.BatchId,
                        Date = intDate,
                        Hour = h.HourString,
                        Receipt = order?.Receipt ?? 0,
                        GTOSales = order?.NetAmount ?? 0,
                        GST = order?.Gst ?? 0,
                        Discount = order?.Discount ?? 0,
                        Pax = h.Pax,
                    };
                }).ToList();        
            return suntecData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        return data;
    }
    public async Task UpdateLog(string fileName, int MachineId, DateTime date, DateTime startDate, int batchId)
    {
        var endDate = DateTime.UtcNow;
        var batchLogger = new BatchLogger()
        {
            BatchId = batchId,
            FileName = fileName,
            MachineId = MachineId,
            Date = date,
            StartDate = startDate,
            EndDate = endDate,
        };
        await _batchRepository.AddLogger(batchLogger);
    }
}
