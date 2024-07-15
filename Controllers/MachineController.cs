using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;


public class MachineController : GenericController<Machine>
{
    private readonly DatabaseRepo<Machine> _repo;

    public MachineController(DatabaseRepo<Machine> repo) : base(repo)
    {
        _repo = repo;
    }
    
   
    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
           var machine = await _repo.GetByIdWithIncludes(x => x.Id == id,
                query => query
                    .Include(m => m.Orders));
        

        return Ok(machine);
    }

    public override async Task<IActionResult> UpdateOne([FromBody] Machine updated)
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

        await _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}