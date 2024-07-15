using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;


public class ProductController : GenericController<Product>
{
    private readonly DatabaseRepo<Product> _repo;

    public ProductController(DatabaseRepo<Product> repo) : base(repo)
    {
        _repo = repo;
    }
    
    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var product = await _repo.GetByIdWithIncludes(x => x.Id == id,
            query => query
                .Include(m => m.Orders));
        return Ok(product);
    }
    
    public override async Task<IActionResult> UpdateOne([FromBody] Product updated)
    {
        Console.WriteLine($"Received update request for Product ID: {updated.Id}");
        var saved = await _repo.GetById(updated.Id);
        if (saved == null) return NotFound("Product not found");
        try
        {
            if (updated.Code != "")
            {
                if (Validation.CheckString(updated.Code))
                    saved.Code = updated.Code;
                else throw new Exception("Provided name was invalid");
            }

            if (updated.Description != null)
            {
                if (Validation.CheckString(updated.Description))
                    saved.Description = updated.Description;
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