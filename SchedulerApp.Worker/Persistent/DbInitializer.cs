using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Persistent;
public class DbInitializer
{
    private readonly LogDbContext _logDbContext;
    public DbInitializer(LogDbContext logDbContext)
    {
        _logDbContext = logDbContext;
    }

    public void Initialize()
    {
        _ = _logDbContext.Database.EnsureCreated();
    }
}
