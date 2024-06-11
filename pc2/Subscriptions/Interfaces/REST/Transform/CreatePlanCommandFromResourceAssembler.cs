using pc2.Subscriptions.Domain.Model.Commands;
using pc2.Subscriptions.Interfaces.REST.Resources;

namespace pc2.Subscriptions.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(resource.Name, resource.MaxUsers, resource.IsDefault);
    }
}