using SchedulerApp.Worker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Repositories;
public interface IBatchRepository
{
    Task<int> GetCurrentBatchId(int machineId, DateTime date);
    Task<BatchLogger?> GetBatchLoggerByDate(DateTime date, int machineId);
    Task AddLogger(BatchLogger logger);
    Task UpdateLogger(BatchLogger logger);
}
