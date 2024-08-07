using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class DeleteProcParamHandler (DatabaseRepo<ProcessParameter> repo) : IRequestHandler<DeleteProductCommand, IActionResult>
{
    public async Task<IActionResult> Handle(DeleteProductCommand request, CancellationToken token)
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