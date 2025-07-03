using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.DTOs;
public class HourData
{
    public int Hour { get; set; }
    public string HourString { get; set; }
    public int MachineId { get; set; }
    public int BatchId { get; set; }
    public int Pax { get; set; }
}
