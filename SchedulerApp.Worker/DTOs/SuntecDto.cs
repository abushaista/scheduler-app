using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.DTOs;
public class SuntecDto
{
    public int MachineId { get; set; }
    public int Date { get; set; }
    public int BatchId { get; set; }
    public string Hour { get; set; }
    public int Receipt { get; set; }
    public decimal GTOSales { get; set; }
    public decimal GST { get; set; }
    public decimal Discount { get; set; }
    public int Pax { get; set; }
}
