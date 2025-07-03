using SchedulerApp.Worker.DTOs;
using SchedulerApp.Worker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Repositories;
public interface IDataRepository
{
    Task<IEnumerable<Order>> GetOrderByDate(DateTime date, int machineId, string locationId);
    Task<IEnumerable<HourlyOrderDTO>> GetHourlyOrderByDate(DateTime date, int machineId, string locationId);
}
