using Microsoft.EntityFrameworkCore;
using pc2.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc2.Shared.Infrastructure.Persistence.EFC.Repositories;
using pc2.Subscriptions.Domain.Model.Aggregates;
using pc2.Subscriptions.Domain.Repositories;

namespace pc2.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository : BaseRepository<Plan>, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Plan?> FindByNameAsync(string name)
    {
        return await Context.Set<Plan>().FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Plan?> FindDefaultPlanAsync()
    {
        return await Context.Set<Plan>().FirstOrDefaultAsync(p => p.IsDefault == 1);
    }
}