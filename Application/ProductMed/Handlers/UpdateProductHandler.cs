using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProductMed.Handlers;

public class UpdateProductHandler (DatabaseRepo<Product> _repo) : IRequestHandler<UpdateProductCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateProductCommand request, CancellationToken token)
    {
        var saved = await _repo.GetById(request.Updated.Id);
        if (saved == null) return new NotFoundObjectResult("ProductMed not found");
        try
        {
            if (request.Updated.Code != "")
            {
                if (saved.Code != request.Updated.Code) saved.Code = request.Updated.Code;
                
            }
            else throw new Exception("Provided name was invalid");
            
            if (request.Updated.Description != null)
            {
                if (saved.Description != request.Updated.Description)
                {
                    saved.Description = request.Updated.Description;
                }
            }
            else throw new Exception("Provided description was invalid");
            await _repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}