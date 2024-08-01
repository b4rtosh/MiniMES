using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Presentation.Controllers;

public class ParamController : GenericController<Parameter>
{
    private readonly IMediator _mediator;

    public ParamController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    
    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllParametersQuery());
        return Ok(all);
    }

    // public override async Task<IActionResult> GetOne([FromRoute] int id)
    // {
    //     var parameter = await _repo.GetByIdWithIncludes(x => x.Id == id,
    //         query => query
    //             .Include(m => m.ProcessParameters));
    //     return Ok(parameter);
    // }
    //
    // public override async Task<IActionResult> UpdateOne([FromBody] Parameter updated)
    // {
    //     var saved = await _repo.GetById(updated.Id);
    //     if (saved == null) return NotFound("Parameter not found");
    //     try
    //     {
    //         if (updated.Name != "")
    //         {
    //             if (Validation.CheckString(updated.Name))
    //                 saved.Name = updated.Name;
    //             else throw new Exception("Provided name was invalid");
    //         }
    //
    //         if (updated.Unit != null)
    //         {
    //             if (Validation.CheckString(updated.Unit))
    //                 saved.Unit = updated.Unit;
    //             else throw new Exception("Provided description was invalid");
    //         }
    //         await _repo.Update(saved);
    //         return Ok($"Updated object:\n{saved}");
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //
    //     
    // }
}