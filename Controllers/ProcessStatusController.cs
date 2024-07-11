using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("api/status")]
public class ProcessStatusController : Controller
{
    private readonly DatabaseRepo<ProcessStatus> _repo;

    public ProcessStatusController(DatabaseRepo<ProcessStatus> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] ProcessStatus status)
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

        await _repo.CreateNew(status);
        return Ok("Status added");
    }


    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var statuses = await _repo.GetAll();
        return Ok(statuses);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var status = await _repo.GetByIdWithIncludes(x => x.Id == id,
            query => query
                .Include(m => m.Processes));
        return Ok(status);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
       await _repo.DelById(id);
        return Ok("Deleted id");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromBody] ProcessStatus updated)
    {
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return BadRequest("Object not found");
        try
        {
            if (updated.Name != "")
            {
                if (Validation.CheckString(updated.Name))
                    saved.Name = updated.Name;
                else throw new Exception("Provided name was invalid");
            }
            await _repo.Update(saved);
            return Ok($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

       
    }
}