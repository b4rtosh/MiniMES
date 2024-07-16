using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    //
    // public override async Task<IActionResult> GetOne([FromRoute] int id)
    // {
    //     var process = await _repo.GetByIdWithIncludes(x => x.Id == id,
    //         query => query
    //             .Include(m => m.Order)
    //             .Include(m => m.ProcessStatus)
    //             .Include(n => n.ProcessParameters)
    //         );
    //     return Ok(process);
    // }
    //
    // public override async Task<IActionResult> UpdateOne([FromBody] Process updated)
    // {
    //     var saved = await _repo.GetById(updated.Id);
    //     if (saved == null) return BadRequest("Object not found");
    //     try
    //     {
    //         if (updated.SerialNumber != "")
    //         {
    //             if (Validation.CheckStringNoSpaces(updated.SerialNumber))
    //                 saved.SerialNumber = updated.SerialNumber;
    //             else throw new Exception("Provided name was invalid");
    //         }
    //
    //         if (updated.OrderId != saved.OrderId) saved.OrderId = updated.OrderId;
    //         if (updated.StatusId != saved.StatusId) saved.StatusId = updated.StatusId;
    //         
    //         await _repo.Update(saved);
    //         return Ok($"Updated object:\n{saved}");
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }
}