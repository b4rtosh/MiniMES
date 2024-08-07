using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProductMed.Handlers;

public class AddProductHandler (DatabaseRepo<Product> repo) : IRequestHandler<AddProductCommand, IActionResult>
{
    public async Task<IActionResult> Handle(AddProductCommand request, CancellationToken token)
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