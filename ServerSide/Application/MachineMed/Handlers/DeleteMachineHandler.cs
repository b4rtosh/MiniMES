using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.MachineMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class DeleteMachineHandler (DatabaseRepo<Machine> repo) : IRequestHandler<DeleteMachineCommand, IActionResult>
{
       public async Task<IActionResult> Handle(DeleteMachineCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repo.DelById(request.Id);
            return new OkObjectResult("Deleted instance");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}