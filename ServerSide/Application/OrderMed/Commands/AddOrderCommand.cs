using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.OrderMed.Commands;

public class AddOrderCommand : IRequest<IActionResult>
{
    public Order Instance { get; set; }
    public AddOrderCommand(Order instance)
    {
        Instance = instance;
    }
}