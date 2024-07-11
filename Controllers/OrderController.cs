using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;
using static MiniMesTrainApi.Models.Validation;

namespace MiniMesTrainApi.Controllers;

[Route("order")]
public class OrderController : Controller
{
    private readonly DatabaseRepo<Order> _repo;

    public OrderController(DatabaseRepo<Order> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromQuery] Order order)
    {
        try
        {
            if (order.Code == "") throw new Exception("Code is required");
            if (!CheckStringNoSpaces(order.Code)) throw new Exception("Code is invalid");
            // how to validate machine id and product id and quantity
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        await _repo.CreateNew(order);
        return Ok("Product added");
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _repo.GetAll();

        return Ok(orders);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        
        var order =  await _repo.GetByIdWithIncludes(x => x.Id == id, query => query
                .Include(x => x.Machine)
                .Include(x => x.Product));
        return Ok(order);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteOne([FromBody] int id)
    {
       await _repo.DelById(id);
        return Ok("Deleted product");
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateOne([FromQuery] string idStr, [FromQuery] Order updated)
    {
        int id;
        if (CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");

        var saved = await _repo.GetById(id);
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
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}