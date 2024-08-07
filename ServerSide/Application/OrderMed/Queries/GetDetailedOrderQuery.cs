using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.OrderMed.Queries;

public class GetDetailedOrderQuery : IRequest<Order>
{
    public long Id { get; set; }
    public GetDetailedOrderQuery(long id)
    {
        Id = id;
    }
}