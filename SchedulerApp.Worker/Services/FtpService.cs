using FluentFTP;
using FluentFTP.Client.Modules;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Services;
public class FtpService : IFtpService
{
    private readonly IConfiguration _config;
    private readonly ILogger<FtpService> _logger;

    public FtpService(IConfiguration config, ILogger<FtpService> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task<bool> UploadFileAsync(string filePath)
    {
        var client = new FtpClient(
               _config["FtpSettings:Host"],
               _config["FtpSettings:Username"],
               _config["FtpSettings:Password"],
               _config.GetValue<int>("FtpSettings:Port", 21)
           );
        try
        {
            client.Connect();
            var remotePath = "/uploads/" + Path.GetFileName(filePath);
            await Task.Run(() => client.UploadFile(filePath, remotePath));
            return true;
        }
        catch (Exception)
        {
            _logger.LogError("Failed to upload file {FilePath} to FTP server.", filePath);
           
        }finally
        {
           if (client != null && client.IsConnected)
            {
               client.Disconnect();
            }
        }
        return false;
    }
}
