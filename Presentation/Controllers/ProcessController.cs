using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ParameterMed.Commands;
using MiniMesTrainApi.Application.ProcessMed.Commands;
using MiniMesTrainApi.Application.ProcessMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers;

public class ProcessController : GenericController<Process>
{
    private readonly IMediator _mediator;

    public ProcessController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllProcessesQuery());
        return Ok(all);
    }

    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        try
        {
            var result = await _mediator.Send(new GetDetailedProcessQuery(id));
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    public override async Task<IActionResult> Add([FromBody] Process instance)
    {
        var result = await _mediator.Send(new AddProcessCommand(instance));
        return result;
    }
    
    public override async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteProcessCommand(id));
        return result;
    }

    public override async Task<IActionResult> UpdateOne([FromBody] Process updated)
    {
        var result = await _mediator.Send(new UpdateProcessCommand(updated));
        return result;
    }
}