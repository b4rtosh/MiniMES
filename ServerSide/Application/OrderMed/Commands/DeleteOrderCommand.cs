using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.OrderMed.Commands;

public class DeleteOrderCommand (long id) : IRequest<IActionResult>
{
    public long Id { get; } = id;
}