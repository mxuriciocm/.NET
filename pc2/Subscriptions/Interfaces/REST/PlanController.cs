using Microsoft.AspNetCore.Mvc;
using pc2.Subscriptions.Application.Internal.CommandServices;
using pc2.Subscriptions.Domain.Services;
using pc2.Subscriptions.Interfaces.REST.Resources;
using pc2.Subscriptions.Interfaces.REST.Transform;

namespace pc2.Subscriptions.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
public class PlanController(IPlanCommandService commandService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        var createPlanCommand = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(createPlanCommand);
        if (result is null) return BadRequest();
        return Ok(resource);
    }
}