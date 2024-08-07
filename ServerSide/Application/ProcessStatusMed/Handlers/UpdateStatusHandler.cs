using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessStatusMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Handlers;

public class UpdateStatusHandler (DatabaseRepo<ProcessStatus> repo)
: IRequestHandler<UpdateStatusCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        var saved = await repo.GetById(request.Updated.Id);
        if (saved == null) return new BadRequestObjectResult("Object not found");
        try
        {
            if (request.Updated.Name != saved.Name) saved.Name = request.Updated.Name;
            await repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}