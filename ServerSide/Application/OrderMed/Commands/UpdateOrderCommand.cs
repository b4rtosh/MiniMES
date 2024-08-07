using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.OrderMed.Commands;

public class UpdateOrderCommand : IRequest<IActionResult>
{
    public Order Updated { get;}
    public UpdateOrderCommand(Order updated)
    {
        Updated = updated;
    }
}