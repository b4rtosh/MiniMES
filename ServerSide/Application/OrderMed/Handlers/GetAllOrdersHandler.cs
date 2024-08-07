using MediatR;
using MiniMesTrainApi.Application.OrderMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class GetAllOrdersHandler (DatabaseRepo<Order> repo) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken token)
    {
        return await repo.GetAll();
    }
}
