using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.OrderMed.Commands;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class AddOrderHandler : IRequestHandler<AddOrderCommand, IActionResult>
{
    private readonly DatabaseRepo<Order> _repo;
    public AddOrderHandler(DatabaseRepo<Order> repo)
    {
        _repo = repo;
    }

    
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