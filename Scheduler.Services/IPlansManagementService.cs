using Scheduler.Services.Models;

namespace Scheduler.Services;

public interface IPlansManagementService
{
    int AddPlan(Plan plan);

    Plan GetPlan(int id);

    IEnumerable<Plan> GetPlans(int offset, int limit);

    bool UpdatePlan(int id, Plan plan);

    bool DeletePlan(int id);
}
