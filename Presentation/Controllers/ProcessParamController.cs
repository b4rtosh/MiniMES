using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Presentation.Controllers;

public class ProcessParamController : GenericController<ProcessParameter>
{
    private readonly IMediator _mediator;

    public ProcessParamController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllProcessParamsQuery());
        return Ok(all);
    }
    //
    // public override async Task<IActionResult> GetOne([FromRoute] int id)
    // {
    //   var processParam = await _repo.GetByIdWithIncludes(x => x.Id == id,
    //       query => query
    //           .Include(x => x.Process)
    //           .Include(x => x.Parameter));
    //     return Ok(processParam);
    // }
    //
    // public override async Task<IActionResult> UpdateOne([FromBody] ProcessParameter updated)
    // {
    //      var saved = await _repo.GetById(updated.Id);
    //      if (saved == null) return BadRequest("Object not found");
    //     try
    //     {
    //         if (updated.ProcessId != saved.ProcessId) saved.ProcessId = updated.ProcessId;
    //         if (updated.ParameterId != saved.ParameterId) saved.ParameterId = updated.ParameterId;
    //         if (updated.Value != saved.Value) saved.Value = updated.Value;
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //     await _repo.Update(saved);
    //     return Ok($"Updated object:\n{saved}");
    // }
}