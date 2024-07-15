using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("api/processparam")]
public class ProcessParamController : Controller
{
    private readonly DatabaseRepo<ProcessParameter> _repo;

    public ProcessParamController(DatabaseRepo<ProcessParameter> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] ProcessParameter processParam)
    {
        try
        {
            if (processParam.Value == 0) throw new Exception("Value is required");
            var response = await _repo.CreateNew(processParam);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var processParams = await _repo.GetAll();

        return Ok(processParams);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
      var processParam = await _repo.GetByIdWithIncludes(x => x.Id == id,
          query => query
              .Include(x => x.Process)
              .Include(x => x.Parameter));
        return Ok(processParam);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        await _repo.DelById(id);
        return Ok("Deleted process processPara");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromBody] ProcessParameter updated)
    {
         var saved = await _repo.GetById(updated.Id);
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