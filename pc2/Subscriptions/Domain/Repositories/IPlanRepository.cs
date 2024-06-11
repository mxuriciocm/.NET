using pc2.Shared.Domain.Repositories;
using pc2.Subscriptions.Domain.Model.Aggregates;

namespace pc2.Subscriptions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<Plan?> FindByNameAsync(string name);
    Task<Plan?> FindDefaultPlanAsync();
}