using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public interface IFtpService
{
    Task<bool> UploadFileAsync(string filePath);
}
