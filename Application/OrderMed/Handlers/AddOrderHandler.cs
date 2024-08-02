using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.OrderMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class AddOrderHandler (DatabaseRepo<Order> _repo) : IRequestHandler<AddOrderCommand, IActionResult>
{ 
    public async Task<IActionResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
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