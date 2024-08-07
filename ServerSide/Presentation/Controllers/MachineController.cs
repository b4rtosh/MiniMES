using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.MachineMed.Commands;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers
{
    public class MachineController : GenericController<Machine>
    {
        private readonly IMediator _mediator;

        public MachineController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

        public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllMachinesQuery());
        return Ok(all);
    }
        public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var machine = await _mediator.Send(new GetDetailedMachinesQuery(id));
        return Ok(machine);
    }

        public override async Task<IActionResult> Add([FromBody] Machine instance)
    {
        var result = await _mediator.Send(new AddMachineCommand(instance));
        return result;
    }
    
        public override async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteMachineCommand(id));
        return result;
    }
    
        public override async Task<IActionResult> UpdateOne([FromBody] Machine updated)
    {
        var result = await _mediator.Send(new UpdateMachineCommand(updated));
        return result;
    }
    }
}