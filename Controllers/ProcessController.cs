using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Controllers;

[Route("api/process")]
public class ProcessController : Controller
{
    private readonly DatabaseRepo<Process> _repo;

    public ProcessController(DatabaseRepo<Process> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Process process)
    {
        try
        {
            if (process.SerialNumber == "") throw new Exception("SerialNumber is required");
            if (!Validation.CheckStringNoSpaces(process.SerialNumber)) throw new Exception("Code is invalid");
            
            process = await _repo.CreateNew(process);
            return Ok(process);
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
        var processes = await _repo.GetAll();

        return Ok(processes);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var process = await _repo.GetByIdWithIncludes(x => x.Id == id,
            query => query
                .Include(m => m.Order)
                .Include(m => m.ProcessStatus)
                .Include(n => n.ProcessParameters)
            );
        return Ok(process);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        await _repo.DelById(id);
        return Ok("Deleted product");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromBody] Process updated)
    {
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return BadRequest("Object not found");
        try
        {
            if (updated.SerialNumber != "")
            {
                if (Validation.CheckStringNoSpaces(updated.SerialNumber))
                    saved.SerialNumber = updated.SerialNumber;
                else throw new Exception("Provided name was invalid");
            }

            if (updated.OrderId != saved.OrderId) saved.OrderId = updated.OrderId;
            if (updated.StatusId != saved.StatusId) saved.StatusId = updated.StatusId;
            
            await _repo.Update(saved);
            return Ok($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        
    }
}