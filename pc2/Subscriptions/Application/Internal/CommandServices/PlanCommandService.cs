using pc2.Shared.Domain.Repositories;
using pc2.Subscriptions.Domain.Model.Aggregates;
using pc2.Subscriptions.Domain.Model.Commands;
using pc2.Subscriptions.Domain.Repositories;
using pc2.Subscriptions.Domain.Services;

namespace pc2.Subscriptions.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{

    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var existingPlan = await planRepository.FindByNameAsync(command.Name);
        if (existingPlan != null)
        {
            throw new Exception("Plan with this name already exists");
        }

        if (command.MaxUsers <= 0)
        {
            throw new Exception("MaxUsers must be greater than zero");
        }

        if (command.IsDefault != 0 && command.IsDefault != 1)
        {
            throw new Exception("IsDefault must be either 0 or 1");
        }

        if (command.IsDefault == 1)
        {
            var defaultPlan = await planRepository.FindDefaultPlanAsync();
            if (defaultPlan != null)
            {
                throw new Exception("A default plan already exists");
            }
        }
        
        var plan = new Plan(command);
        try
        {
            await planRepository.AddAsync(plan);
            await unitOfWork.CompleteAsync();
        } catch (Exception e)
        {
            return null;
        }

        return plan;
    }
}