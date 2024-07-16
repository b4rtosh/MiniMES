using MediatR;
using MiniMesTrainApi.Application.OrderM.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.OrderMed.Handlers;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly DatabaseRepo<Order> _repo;

    public GetAllOrdersHandler(DatabaseRepo<Order> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}
