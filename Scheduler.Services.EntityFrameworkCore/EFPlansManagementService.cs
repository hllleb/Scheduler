using Microsoft.EntityFrameworkCore;
using Scheduler.Services.EntityFrameworkCore.Context;
using PlanModel = Scheduler.Services.Models.Plan;
using PlanEntity = Scheduler.Services.EntityFrameworkCore.Entities.Plan;

namespace Scheduler.Services.EntityFrameworkCore;

public class EFPlansManagementService : IPlansManagementService
{
    private readonly SchedulerContext dbContext;

    public EFPlansManagementService(SchedulerContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public int AddPlan(PlanModel plan)
    {
        var entry = this.dbContext.Add(MapPlanModel(plan));
        this.dbContext.SaveChanges();
        return entry.Entity.Id;
    }

    public PlanModel GetPlan(int id)
    {
        var entity = this.dbContext.Find<PlanEntity>(id);
        if (entity is null)
        {
            return null;
        }

        return MapPlanEntity(entity);
    }

    public IEnumerable<PlanModel> GetPlans(int offset, int limit)
    {
        return this.dbContext.Set<PlanEntity>()
                             .Select(MapPlanEntity)
                             .Skip(offset)
                             .Take(limit);
    }

    public bool UpdatePlan(int id, PlanModel plan)
    {
        var entity = this.dbContext.Find<PlanEntity>(id);
        if (entity is null)
        {
            return false;
        }

        entity.Name = plan.Name;
        entity.StartTime = plan.StartTime;
        entity.Duration = plan.Duration;
        entity.Description = plan.Description;

        this.dbContext.Update(entity);

        return this.dbContext.SaveChanges() > 0;
    }

    public bool DeletePlan(int id)
    {
        var entity = this.dbContext.Find<PlanEntity>(id);
        if (entity is null)
        {
            return false;
        }

        this.dbContext.Remove(entity);

        return this.dbContext.SaveChanges() > 0;
    }

    private PlanEntity MapPlanModel(PlanModel plan) =>
        new()
        {
            Id = plan.Id,
            Name = plan.Name,
            StartTime = plan.StartTime,
            Duration = plan.Duration,
            Description = plan.Description
        } ;

    private PlanModel MapPlanEntity(PlanEntity plan) =>
        new()
        {
            Id = plan.Id,
            Name = plan.Name,
            StartTime = plan.StartTime,
            Duration = plan.Duration,
            Description = plan.Description
        };
}