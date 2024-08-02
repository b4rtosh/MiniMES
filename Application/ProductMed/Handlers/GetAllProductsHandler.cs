using MediatR;
using MiniMesTrainApi.Application.OrderM.Queries;
using MiniMesTrainApi.Application.ProductMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProductMed.Handlers;

public class GetAllProductsHandler (DatabaseRepo<Product> _repo) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}