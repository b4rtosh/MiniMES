using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ParameterMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ParameterMed.Handlers;

public class AddParamHandler (DatabaseRepo<Parameter> repo) : IRequestHandler<AddParamCommand, IActionResult>
{
    public async Task<IActionResult> Handle(AddParamCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newInstance = await repo.CreateNew(request.Instance);
            return new OkObjectResult(newInstance);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}