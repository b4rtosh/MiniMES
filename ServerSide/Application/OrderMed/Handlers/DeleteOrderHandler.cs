using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.OrderMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class DeleteOrderHandler (DatabaseRepo<Order> repo) : IRequestHandler<DeleteOrderCommand, IActionResult>
{
    public async Task<IActionResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
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