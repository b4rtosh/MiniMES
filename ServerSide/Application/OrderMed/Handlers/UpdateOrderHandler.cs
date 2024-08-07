using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.OrderMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class UpdateOrderHandler (DatabaseRepo<Order> repo) : IRequestHandler<UpdateOrderCommand, IActionResult>
{
    public async Task<IActionResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var saved = await repo.GetById(request.Updated.Id);
        if (saved == null) return new BadRequestObjectResult("Object not found");
        try
        {
            if (request.Updated.MachineId != saved.MachineId) saved.MachineId = request.Updated.MachineId;
            if (request.Updated.ProductId != saved.ProductId) saved.ProductId = request.Updated.ProductId;
            if (request.Updated.Quantity != saved.Quantity) saved.Quantity = request.Updated.Quantity;
            
            await repo.Update(saved);
            return new OkObjectResult($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}