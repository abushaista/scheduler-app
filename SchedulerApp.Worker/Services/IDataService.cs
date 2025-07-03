using SchedulerApp.Worker.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public interface IDataService
{
    Task<IEnumerable<SuntecDto>> GetSuntecDataAsync(DateTime date, int machineId, string locationId);
    Task UpdateLog(string fileName, int MachineId, DateTime date, DateTime startDate, int batchId);
}
