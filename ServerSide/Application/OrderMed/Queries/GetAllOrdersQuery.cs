using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.OrderMed.Queries;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>{}