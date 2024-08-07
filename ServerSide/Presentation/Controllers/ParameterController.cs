using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ParameterMed.Commands;
using MiniMesTrainApi.Application.ParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers
{
    public class ParamController : GenericController<Parameter>
    {
        private readonly IMediator _mediator;

        public ParamController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    
        public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllParamsQuery());
        return Ok(all);
    }

        public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetDetailedParamQuery(id));
        return Ok(result);
    }

        public override async Task<IActionResult> Add([FromBody] Parameter instance)
    {
        var result = await _mediator.Send(new AddParamCommand(instance));
        return result;
    }

        public override async Task<IActionResult> UpdateOne([FromBody] Parameter updated)
    {
        var result = await _mediator.Send(new UpdateParamCommand(updated));
        return result;
    }
    }
}