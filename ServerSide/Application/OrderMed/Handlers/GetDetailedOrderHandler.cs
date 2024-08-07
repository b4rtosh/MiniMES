using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.OrderMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class GetDetailedOrderHandler (DatabaseRepo<Order> repo) : IRequestHandler<GetDetailedOrderQuery, Order>
{
    public async Task<Order> Handle(GetDetailedOrderQuery request, CancellationToken token)
    {
        var order =  await repo.GetByIdWithIncludes(x => x.Id == request.Id,
            query => query
            .Include(x => x.Machine)
            .Include(x => x.Product)
            .Include(m => m.Processes));
        return order;
    }
}