using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Models;
using MiniMesTrainApi.Repositories;

namespace MiniMesTrainApi.Controllers;

[Route("product")]
public class ProductController : Controller
{
    private readonly DatabaseRepo<Product> _repo;

    public ProductController(DatabaseRepo<Product> repo)
    {
        _repo = repo;
    }

    [HttpPut]
    [Route("add")]
    public IActionResult Add([FromQuery] Product product)
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

        _repo.CreateNew(product);
        return Ok("Product added");
    }

    [HttpGet]
    [Route("all")]
    public IActionResult GetAll()
    {
        var products = _repo.GetAll();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetOne([FromRoute] string idStr)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var product = _repo.GetById(id);
        return Ok(product);
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
    public async Task<IActionResult> UpdateOne([FromQuery] string idStr, [FromQuery] Product updated)
    {
        int id;
        if (Validation.CheckInteger(idStr))
            id = Convert.ToInt32(idStr);
        else return BadRequest("Id is not an integer.");
        var saved = await _repo.GetById(id);
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
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _repo.Update(saved);
        return Ok($"Updated object:\n{saved}");
    }
}