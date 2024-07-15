using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;
using static MiniMesTrainApi.Models.Validation;

namespace MiniMesTrainApi.Controllers;

public class OrderController : GenericController<Order>
{
    private readonly DatabaseRepo<Order> _repo;

    public OrderController(DatabaseRepo<Order> repo) : base(repo)
    {
        _repo = repo;
    }
    
    public override async Task<IActionResult> GetOne([FromRoute] long id)
    {
        var order =  await _repo.GetByIdWithIncludes(x => x.Id == id, query => query
                .Include(x => x.Machine)
                .Include(x => x.Product)
            .Include(m => m.Processes));
        return Ok(order);
    }

   
    public override async Task<IActionResult> UpdateOne([FromBody] Order updated)
    {
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return BadRequest("Object not found");
        try
        {
            if (updated.Code != "")
            {
                if (CheckString(updated.Code))
                    saved.Code = updated.Code;
                else throw new Exception("Provided name was invalid");
            }

            if (updated.MachineId != saved.MachineId) saved.MachineId = updated.MachineId;
            if (updated.ProductId != saved.ProductId) saved.ProductId = updated.ProductId;
            if (updated.Quantity != saved.Quantity) saved.Quantity = updated.Quantity;
            
            await _repo.Update(saved);
            return Ok($"Updated object:\n{saved}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

      
    }
}