using System.Collections;
using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.OrderM.Queries;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>{}