using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessStatusMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Handlers;

public class DeleteStatusHandler (DatabaseRepo<ProcessStatus> _repo)
: IRequestHandler<DeleteStatusCommand, IActionResult>
{
    public async Task<IActionResult> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repo.DelById(request.Id);
            return new OkObjectResult("Deleted Status");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}