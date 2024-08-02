using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ParameterMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ParameterMed.Handlers;

public class DeleteParamHandler (DatabaseRepo<Parameter> _repo) : IRequestHandler<DeleteParamCommand, IActionResult>
{
    public async Task<IActionResult> Handle(DeleteParamCommand request, CancellationToken token)
    {
        try
        {
            await _repo.DelById(request.Id);
            return new OkObjectResult("Deleted instance");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}