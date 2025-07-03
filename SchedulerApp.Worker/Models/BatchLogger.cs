using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Models;
public class BatchLogger
{
    public int Id { get; set; }
    public int BatchId { get; set; }
    public int MachineId { get; set; }
    public DateTime Date { get; set; }
    public string FileName { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
}
