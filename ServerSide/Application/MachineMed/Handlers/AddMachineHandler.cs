using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.MachineMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class AddMachineHandler (DatabaseRepo<Machine> repo) : IRequestHandler<AddMachineCommand, IActionResult>
{ 
    public async Task<IActionResult> Handle(AddMachineCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var instance = await repo.CreateNew(request.Instance);
            return new OkObjectResult(instance);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
 