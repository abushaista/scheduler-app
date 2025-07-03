using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.DTOs;
public class HourlyOrderDTO
{
    public int Hour { get; set; } // Represents the hour of the day (0-23)
    public DateTime Date { get; set; } // Represents the date for which the hourly data is collected
    public int Receipt { get; set; } // Total quantity of orders for that hour
    public decimal NetAmount { get; set; } // Total net amount of orders for that hour
    public decimal Gst { get; set; } // Total amount of orders for that hour
    public decimal Discount { get; set; } // Total discount applied to orders for that hour
}
