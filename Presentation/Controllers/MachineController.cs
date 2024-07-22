using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Presentation.Controllers;


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

    // public override async Task<IActionResult> UpdateOne([FromBody] Machine updated)
    // {
    //     var saved = await _repo.GetById(updated.Id);
    //     if (saved == null) return NotFound("Machine not found");
    //     try
    //     {
    //         if (saved.Name != updated.Name) saved.Name = updated.Name;
    //       if (saved.Description != updated.Description) saved.Description = updated.Description;
    //         
    //         await _repo.Update(saved);
    //         return Ok($"Updated object:\n{saved}");
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e);
    //     }
    //
    //
    // }
}