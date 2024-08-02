using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessParameterMed.Commands;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class UpdateProcParamHandler (DatabaseRepo<ProcessParameter> _repo) 
    : IRequestHandler<UpdateProcParamCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateProcParamCommand request, CancellationToken token)
    {
        var saved = await _repo.GetById(request.Updated.Id);
        if (saved == null) return new BadRequestObjectResult("Object not found");
        try
        {
            if (request.Updated.ProcessId != saved.ProcessId) saved.ProcessId = request.Updated.ProcessId;
            if (request.Updated.ParameterId != saved.ParameterId) saved.ParameterId = request.Updated.ParameterId;
            if (request.Updated.Value != saved.Value) saved.Value = request.Updated.Value;
            await _repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
      
    }
}