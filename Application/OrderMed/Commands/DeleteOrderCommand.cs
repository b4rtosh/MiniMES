using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.OrderMed.Commands;

public class DeleteOrderCommand : IRequest<IActionResult>
{
    public int Id { get; }
    public DeleteOrderCommand(int id)
    {
        Id = id;
    }
}