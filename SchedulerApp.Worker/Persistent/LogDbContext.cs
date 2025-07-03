using Microsoft.EntityFrameworkCore;
using SchedulerApp.Worker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Worker.Persistent;
public class LogDbContext : DbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
    public DbSet<BatchLogger> BatchLoggers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchLogger>().HasKey(bl => bl.Id);
        modelBuilder.Entity<BatchLogger>().Property(b => b.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<BatchLogger>().HasIndex(b => b.BatchId).HasDatabaseName("IX_BatchId");
        modelBuilder.Entity<BatchLogger>().HasIndex(b => b.Date).HasDatabaseName("IX_Date");
    }
}

