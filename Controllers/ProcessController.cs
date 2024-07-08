using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("process")]
public class ProcessController : Controller
{
    private readonly DatabaseRepo<Process> _repo;

    public ProcessController(DatabaseRepo<Process> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] Process process)
    {
        try
        {
            if (process.SerialNumber == "") throw new Exception("SerialNumber is required");
            if (!Validation.CheckStringNoSpaces(process.SerialNumber)) throw new Exception("Code is invalid");
            // how to validate machine id and product id and quantity
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        _repo.CreateNew(process);
        return Ok("Process added");
    }

    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var processes = _repo.GetAll();

        return Ok(processes);
    }

    [HttpGet]
    [Route("{idStr}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        var process = _repo.GetById(id);
        return Ok(process);
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
        return Ok("Deleted product");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromQuery] string idStr, [FromQuery] Process updated)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        var saved = await _repo.GetById(id);
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
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}