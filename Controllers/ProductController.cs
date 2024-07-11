using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("api/product")]
public class ProductController : Controller
{
    private readonly DatabaseRepo<Product> _repo;

    public ProductController(DatabaseRepo<Product> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Product product)
    {
        try
        {
            if (product.Code == "") throw new Exception("Code is required");
            if (!Validation.CheckStringNoSpaces(product.Code)) throw new Exception("Name is invalid");
            if (product.Description == null) throw new Exception("Description is required");
            if (!Validation.CheckString(product.Description)) throw new Exception("Description is invalid");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        await _repo.CreateNew(product);
        return Ok("Product added");
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repo.GetAll();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var product = await _repo.GetByIdWithIncludes(x => x.Id == id,
            query => query
                .Include(m => m.Orders));
        return Ok(product);
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
    public async Task<IActionResult> UpdateOne([FromBody] Product updated)
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