using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessParameterMed.Commands;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class AddProcParamHandler (DatabaseRepo<ProcessParameter> _repo) : IRequestHandler<AddProcParamCommand, IActionResult>
{
    public async Task<IActionResult> Handle(AddProcParamCommand request, CancellationToken token)
    {
        try
        {
            var instance = await _repo.CreateNew(request.Instance);
            return new OkObjectResult(instance);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}