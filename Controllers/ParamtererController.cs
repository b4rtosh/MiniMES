using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Controllers;

[Route("api/parameter")]
public class ParamController : Controller
{
    private readonly DatabaseRepo<Parameter> _repo;

    public ParamController(DatabaseRepo<Parameter> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Parameter parameter)
    {
        try
        {
            if (parameter.Name == "") throw new Exception("Name is required");
            if (!Validation.CheckString(parameter.Name)) throw new Exception("Name is invalid");
            if (parameter.Unit == null) throw new Exception("Unit is required");
            if (!Validation.CheckStringNoSpaces(parameter.Unit)) throw new Exception("Description is invalid");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        await _repo.CreateNew(parameter);
        return Ok("Parameter added");
    }


    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var parameters = await _repo.GetAll();
        return Ok(parameters);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var parameter = await _repo.GetByIdWithIncludes(x => x.Id == id,
            query => query
                .Include(m => m.ProcessParameters));
        return Ok(parameter);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOne([FromRoute] int id)
    {
        await _repo.DelById(id);
        return Ok("Deleted processPara");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromBody] Parameter updated)
    {
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return NotFound("Parameter not found");
        try
        {
            if (updated.Name != "")
            {
                if (Validation.CheckString(updated.Name))
                    saved.Name = updated.Name;
                else throw new Exception("Provided name was invalid");
            }

            if (updated.Unit != null)
            {
                if (Validation.CheckString(updated.Unit))
                    saved.Unit = updated.Unit;
                else throw new Exception("Provided description was invalid");
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