using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("processPara")]
public class ParamController : Controller
{
    private readonly DatabaseRepo<Parameter> _repo;

    public ParamController(DatabaseRepo<Parameter> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] Parameter parameter)
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

        _repo.CreateNew(parameter);
        return Ok("Parameter added");
    }


    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var parameters = _repo.GetAll();
        return Ok(parameters);
    }

    [HttpGet]
    [Route("{order}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var parameter = _repo.GetById(id);
        return Ok(parameter);
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteOne([FromBody] int id)
    {
        _repo.DelById(id);
        return Ok("Deleted processPara");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromQuery] string idStr, [FromQuery] Parameter updated)
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

            if (updated.Unit != null)
            {
                if (Validation.CheckString(updated.Unit))
                    saved.Unit = updated.Unit;
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