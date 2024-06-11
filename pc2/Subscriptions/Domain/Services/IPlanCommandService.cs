using pc2.Subscriptions.Domain.Model.Aggregates;
using pc2.Subscriptions.Domain.Model.Commands;

namespace pc2.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand command);
}