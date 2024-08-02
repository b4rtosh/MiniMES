using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProductMed.Queries;

public class GetDetailedProductQuery (int id) : IRequest<Product>
{
    public int Id { get; set; } = id;
}