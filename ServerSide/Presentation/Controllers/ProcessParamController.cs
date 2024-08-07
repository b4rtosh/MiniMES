using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProcessParameterMed.Commands;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers
{
    public class ProcessParamController : GenericController<ProcessParameter>
    {
        private readonly IMediator _mediator;

        public ProcessParamController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

        public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllProcParamsQuery());
        return Ok(all);
    }
    
        public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetDetailedProcParamQuery(id));
        return Ok(product);
    }
    
        public override async Task<IActionResult> Add([FromBody] ProcessParameter instance)
    {
        var result = await _mediator.Send(new AddProcParamCommand(instance));
        return result;
    }   
    
        public override async Task<IActionResult> UpdateOne([FromBody] ProcessParameter updated)
    {
        var result = await _mediator.Send(new UpdateProcParamCommand(updated));
        return result;
    }
    
        public override async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteProcParamCommand(id));
        return result;
    }

    }
}