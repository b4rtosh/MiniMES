using MediatR;
using MiniMesTrainApi.Application.OrderM.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class GetAllOrdersHandler (DatabaseRepo<Order> _repo) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}
