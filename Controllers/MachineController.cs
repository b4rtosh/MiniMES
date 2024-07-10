using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

// [ApiController]
[Route("/api/machine/")]
public class MachineController : Controller
{
    private readonly DatabaseRepo<Machine> _repo;

    public MachineController(DatabaseRepo<Machine> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Machine machine)
    {
        try
        {
            if (machine.Name == "") throw new Exception("Name is required");
            if (!Validation.CheckString(machine.Name)) throw new Exception("Name is invalid");
            if (machine.Description == null) throw new Exception("Description is required");
            if (!Validation.CheckString(machine.Description)) throw new Exception("Description is invalid");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        await _repo.CreateNew(machine);
        return Ok(machine);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var machines = await _repo.GetAll();
        return Ok(machines);
    }


    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var machine = await _repo.GetById(id);
        return Ok(machine);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        await _repo.DelById(id);
        return Ok("Deleted machine");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromBody] Machine updated)
    {
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return NotFound("Machine not found");
        try
        {
            if (updated.Name != "")
            {
                if (Validation.CheckString(updated.Name))
                    saved.Name = updated.Name;
                else throw new Exception("Provided name was invalid");
            }

            if (updated.Description != null)
            {
                if (Validation.CheckString(updated.Description))
                    saved.Description = updated.Description;
                else throw new Exception("Provided description was invalid");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}