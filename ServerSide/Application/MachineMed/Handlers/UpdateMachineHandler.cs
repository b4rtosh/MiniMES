using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.MachineMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class UpdateMachineHandler (DatabaseRepo<Machine> repo) : IRequestHandler<UpdateMachineCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateMachineCommand request, CancellationToken cancellationToken)
    {
        var saved = await repo.GetById(request.Updated.Id);
        if (saved == null) return new NotFoundObjectResult("Machine not found");
        try
        {
            if (saved.Name != request.Updated.Name) saved.Name = request.Updated.Name;
            if (saved.Description != request.Updated.Description) saved.Description = request.Updated.Description;
            
            await repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e);
        }
    }
}
