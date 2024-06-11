using pc2.Subscriptions.Domain.Model.Aggregates;
using pc2.Subscriptions.Domain.Model.Commands;
using pc2.Subscriptions.Interfaces.REST.Resources;

namespace pc2.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity) => new PlanResource(entity.Id, entity.Name, entity.MaxUsers);
}
