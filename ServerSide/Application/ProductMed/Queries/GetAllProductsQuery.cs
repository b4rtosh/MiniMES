using MediatR;

namespace MiniMesTrainApi.Application.ProductMed.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
{
}