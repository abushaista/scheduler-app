using SchedulerApp.Worker.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public interface IFileService
{
    Task<string> GenerateFileAsync(IEnumerable<SuntecDto> data, DateTime date, int machineId);
}
