using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessStatusMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Handlers;

public class AddStatusHandler (DatabaseRepo<ProcessStatus> _repo)
: IRequestHandler<AddStatusCommand, IActionResult>
{
    public async Task<IActionResult> Handle(AddStatusCommand request, CancellationToken token)
    {
        try
        {
            var result = await _repo.CreateNew(request.Instance);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}