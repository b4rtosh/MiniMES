using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessMed.Handlers;

public class AddProcessHandler(DatabaseRepo<Process> _repo) : IRequestHandler<AddProcessCommand, IActionResult>
{
    public async Task<IActionResult> Handle(AddProcessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var process = await _repo.CreateNew(request.Instance);
            return new OkObjectResult(process);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}