using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessMed.Handlers;

public class UpdateProcessHandler (DatabaseRepo<Process> repo) : IRequestHandler<UpdateProcessCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateProcessCommand request, CancellationToken token)
    {
        var saved = await repo.GetById(request.Updated.Id);
        if (saved == null) return new BadRequestObjectResult("Object not found");
        try
        {
            if (request.Updated.SerialNumber != saved.SerialNumber)   saved.SerialNumber = request.Updated.SerialNumber;
            if (request.Updated.OrderId != saved.OrderId) saved.OrderId = request.Updated.OrderId;
            if (request.Updated.StatusId != saved.StatusId) saved.StatusId = request.Updated.StatusId;
            
            await repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}