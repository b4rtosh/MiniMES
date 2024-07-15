using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

public class ProcessParamController : GenericController<ProcessParameter>
{
    private readonly DatabaseRepo<ProcessParameter> _repo;

    public ProcessParamController(DatabaseRepo<ProcessParameter> repo) : base(repo)
    {
        _repo = repo;
    }

    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
      var processParam = await _repo.GetByIdWithIncludes(x => x.Id == id,
          query => query
              .Include(x => x.Process)
              .Include(x => x.Parameter));
        return Ok(processParam);
    }

    public override async Task<IActionResult> UpdateOne([FromBody] ProcessParameter updated)
    {
         var saved = await _repo.GetById(updated.Id);
         if (saved == null) return BadRequest("Object not found");
        try
        {
            if (updated.ProcessId != saved.ProcessId) saved.ProcessId = updated.ProcessId;
            if (updated.ParameterId != saved.ParameterId) saved.ParameterId = updated.ParameterId;
            if (updated.Value != saved.Value) saved.Value = updated.Value;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        await _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}