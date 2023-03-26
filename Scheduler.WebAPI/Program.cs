using Microsoft.EntityFrameworkCore;
using Scheduler.Services;
using Scheduler.Services.EntityFrameworkCore;
using Scheduler.Services.EntityFrameworkCore.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddTransient<IPlansManagementService, EFPlansManagementService>();
builder.Services.AddDbContext<SchedulerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
