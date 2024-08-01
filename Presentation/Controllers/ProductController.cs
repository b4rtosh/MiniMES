using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.ProductMed.Commands;
using MiniMesTrainApi.Application.ProductMed.Queries;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Presentation.Controllers;


public class ProductController : GenericController<Product>
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    public override async Task<IActionResult> GetAll()
    {
        var all = await _mediator.Send(new GetAllProductsQuery());
        return Ok(all);
    }

    public override async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetDetailedProductQuery(id));
        return Ok(product);
    }

    public override async Task<IActionResult> Add([FromBody] Product instace)
    {
        var result = await _mediator.Send(new AddProductCommand(instace));
        return result;
    }   
    
    public override async Task<IActionResult> UpdateOne([FromBody] Product updated)
    {
        var result = await _mediator.Send(new UpdateProductCommand(updated));
        return result;
    }
}