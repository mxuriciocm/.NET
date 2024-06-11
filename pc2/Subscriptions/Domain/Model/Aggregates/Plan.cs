using pc2.Subscriptions.Domain.Model.Commands;

namespace pc2.Subscriptions.Domain.Model.Aggregates;

/**
 * Plan.cs
 * <summary>
 * Entity class for Plan
 */

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxUsers { get; set; }
    public int IsDefault { get; set; }

    protected Plan()
    {
        this.Name = string.Empty;
        this.MaxUsers = 0;
        this.IsDefault = 0;
    }

    public Plan(CreatePlanCommand command)
    {
        this.Name = command.Name;
        this.MaxUsers = command.MaxUsers;
        this.IsDefault = command.IsDefault;
    }
}