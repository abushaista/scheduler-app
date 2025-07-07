using Microsoft.EntityFrameworkCore;
using SchedulerApp.Worker.DTOs;
using SchedulerApp.Worker.Models;
using SchedulerApp.Worker.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Repositories;
public class DataRepository : IDataRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<DataRepository> _logger;

    public DataRepository(AppDbContext context, ILogger<DataRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Order>> GetOrderByDate(DateTime date, int machineId, string locationId)
    {
        try
        {
            var LocID = new Guid(locationId);
            var data = await _context.Orders
                .Where(x => x.OrderDate.Date == date.Date && x.LocationID == LocID)
                .ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving orders for date {Date}, machine ID {MachineId}, location ID {LocationId}", date, machineId, locationId);
            return Enumerable.Empty<Order>();
        }
    }

    public async Task<IEnumerable<HourlyOrderDTO>> GetHourlyOrderByDate(DateTime date, int machineId, string locationId)
    {
        try
        {
            var LocID = new Guid(locationId);
            var qry = _context.Orders.Where(x => x.OrderDate.Date == date.Date && x.LocationID == LocID)
                .GroupBy(o => o.OrderDate.Hour)
                .Select(g => new HourlyOrderDTO
                {
                    Hour = g.Key,
                    Date = date,
                    Receipt = g.Count(),
                    NetAmount = g.Sum(o => o.NetAmount),
                    Gst = g.Sum(o => o.TaxAmount),
                    Discount = g.Sum(o => o.DiscountAmount)
                }).ToQueryString();
            var data = await _context.Orders.Where(x => x.OrderDate.Date == date.Date && x.LocationID == LocID)
                .GroupBy(o => o.OrderDate.Hour)
                .Select(g => new HourlyOrderDTO
                {
                    Hour = g.Key,
                    Date = date,
                    Receipt = g.Count(),
                    NetAmount = g.Sum(o => o.NetAmount),
                    Gst = g.Sum(o => o.TaxAmount),
                    Discount = g.Sum(o => o.DiscountAmount)
                }).ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving orders for date {Date}, machine ID {MachineId}, location ID {LocationId}", date, machineId, locationId);
            return Enumerable.Empty<HourlyOrderDTO>();
        }
    }
}
