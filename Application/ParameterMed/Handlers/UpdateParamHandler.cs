using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ParameterMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ParameterMed.Handlers;

public class UpdateParamHandler (DatabaseRepo<Parameter> _repo) : IRequestHandler<UpdateParamCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateParamCommand request, CancellationToken token)
    {
        var saved = await _repo.GetById(request.Updated.Id);
        if (saved == null) return new NotFoundObjectResult("Parameter not found");
        try
        {
            if (request.Updated.Name != saved.Name) saved.Name = request.Updated.Name;
            if (request.Updated.Unit != saved.Unit) saved.Unit = request.Updated.Unit;
            await _repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}