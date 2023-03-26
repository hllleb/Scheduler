using Microsoft.EntityFrameworkCore;
using Scheduler.Services.EntityFrameworkCore.Entities;

namespace Scheduler.Services.EntityFrameworkCore.Context;

public class SchedulerContext : DbContext
{
    public SchedulerContext()
    {
        
    }

    public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
    {
        
    }

    public DbSet<Plan> Plans { get; set; }
}