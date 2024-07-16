using MediatR;

namespace MiniMesTrainApi.Application.Product.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
{
}