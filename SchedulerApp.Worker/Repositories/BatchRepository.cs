using Microsoft.EntityFrameworkCore;
using SchedulerApp.Worker.Models;
using SchedulerApp.Worker.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Repositories;
public class BatchRepository : IBatchRepository
{
    private readonly LogDbContext _context;
    private readonly ILogger<BatchRepository> _logger;

    public BatchRepository(LogDbContext context, ILogger<BatchRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddLogger(BatchLogger logger)
    {
        _context.Add(logger);
        await _context.SaveChangesAsync();
    }

    public async Task<BatchLogger?> GetBatchLoggerByDate(DateTime date, int machineId)
    {
        try
        {
            var batchLogger = await _context.BatchLoggers
           .Where(x => x.Date.Date == date.Date && x.MachineId == machineId)
           .FirstOrDefaultAsync();
            return batchLogger;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving batch logger for date {Date} and machine ID {MachineId}", date, machineId);
            return null;
        }
    }

    public async Task<int> GetCurrentBatchId(int machineId, DateTime date)
    {
        try
        {
            var batch = await _context.BatchLoggers
            .Where(x => x.Date.Date == date.Date && x.MachineId == machineId)
            .FirstOrDefaultAsync();
            if (batch == null)
            {
                var batchId = await _context.BatchLoggers
                    .Where(x => x.MachineId == machineId)
                    .MaxAsync(x => x.BatchId) + 1;
                return batchId;
            }
            return batch.BatchId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving current batch ID for machine ID {MachineId} on date {Date}", machineId, date);
            return 1; // or handle as appropriate
        }
        
    }

    public async Task UpdateLogger(BatchLogger logger)
    {
        try
        {
            _context.Update(logger);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating batch logger for machine ID {MachineId} on date {Date}", logger.MachineId, logger.Date);
        }
    }
}
