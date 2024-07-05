using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

// [ApiController]
[Route("api/v1/machine")]
public class MachineController : Controller
{
    private readonly DatabaseRepo<Machine> _repo;

    public MachineController(DatabaseRepo<Machine> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] Machine machine)
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

        _repo.CreateNew(machine);
        return Ok("Machine added");
    }


    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var machines = _repo.GetAll();
        return Ok(machines);
    }

    [HttpGet]
    [Route("{idStr}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var machine = _repo.GetById(id);
        return Ok(machine);
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
        return Ok("Deleted machine");
    }

    [HttpPost]
    [Route("update")]
    public IActionResult UpdateOne([FromQuery] string idStr, [FromQuery] Machine updated)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var saved = _repo.GetById(id);
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
            return BadRequest(e.Message);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}