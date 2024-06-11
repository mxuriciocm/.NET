namespace pc2.Subscriptions.Interfaces.REST.Resources;

public record CreatePlanResource(string Name, int MaxUsers, int IsDefault);