using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("api/v1/processparam")]
public class ProcessParamController : Controller
{
    private readonly DatabaseRepo<ProcessParameter> _repo;

    public ProcessParamController(DatabaseRepo<ProcessParameter> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] ProcessParameter processParam)
    {
        _repo.CreateNew(processParam);
        return Ok("Process added");
    }

    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var processParams = _repo.GetAll();

        return Ok(processParams);
    }

    [HttpGet]
    [Route("{idStr}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        var processParam = _repo.GetById(id);
        return Ok(processParam);
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteOne([FromQuery] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        _repo.DelById(id);
        return Ok("Deleted process parameter");
    }

    [HttpPost]
    [Route("update")]
    public IActionResult UpdateOne([FromQuery] string idStr, [FromQuery] ProcessParameter updated)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        var saved = _repo.GetById(id);
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

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}