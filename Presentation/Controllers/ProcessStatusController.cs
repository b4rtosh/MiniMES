using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ProcessStatusMed.Commands;
using MiniMesTrainApi.Application.ProcessStatusMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Presentation.Controllers;

public class StatusController : GenericController<ProcessStatus>
{
    private readonly IMediator _mediator;

    public StatusController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllStatusesQuery());
        return Ok(all);
    }
    
    public override async Task<IActionResult> Add([FromBody] ProcessStatus instance)
    {
        return await _mediator.Send(new AddStatusCommand(instance));
    }
    
    public override async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        return await _mediator.Send(new DeleteStatusCommand(id));
    }
    
    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        return Ok(await _mediator.Send(new GetDetailedStatusQuery(id)));
    }

    public override async Task<IActionResult> UpdateOne([FromBody] ProcessStatus updated)
    {
        return await _mediator.Send(new UpdateStatusCommand(updated));
    }
}