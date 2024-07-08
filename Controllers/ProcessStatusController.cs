using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("status")]
public class ProcessStatusController : Controller
{
    private readonly DatabaseRepo<ProcessStatus> _repo;

    public ProcessStatusController(DatabaseRepo<ProcessStatus> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] ProcessStatus status)
    {
        try
        {
            if (status.Name == "") throw new Exception("Name is required");
            if (!Validation.CheckString(status.Name)) throw new Exception("Name is invalid");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        _repo.CreateNew(status);
        return Ok("Status added");
    }


    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var statuses = _repo.GetAll();
        return Ok(statuses);
    }

    [HttpGet]
    [Route("{idStr}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var status = _repo.GetById(id);
        return Ok(status);
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
        return Ok("Deleted status");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromQuery] string idStr, [FromQuery] ProcessStatus updated)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var saved = await _repo.GetById(id);
        try
        {
            if (updated.Name != "")
            {
                if (Validation.CheckString(updated.Name))
                    saved.Name = updated.Name;
                else throw new Exception("Provided name was invalid");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}