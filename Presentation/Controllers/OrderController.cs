using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.OrderM.Queries;
using MiniMesTrainApi.Application.OrderMed.Commands;
using MiniMesTrainApi.Application.OrderMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers;

public class OrderController : GenericController<Order>
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(all);
    }
    
    public override async Task<IActionResult> GetOne([FromRoute] long id)
    {
        var machine = await _mediator.Send(new GetDetailedOrderQuery(id));
        return Ok(machine);
    }
    
    public override async Task<IActionResult> UpdateOne([FromBody] Order updated)
    {
        var result = await _mediator.Send(new UpdateOrderCommand(updated));
        return result;
    }
    
    public override async Task<IActionResult> Add([FromBody] Order instance)
    {
        var result = await _mediator.Send(new AddOrderCommand(instance));
        return result;
    }
}