namespace pc2.Subscriptions.Domain.Model.Commands;

public record CreatePlanCommand(string Name, int MaxUsers, int IsDefault);