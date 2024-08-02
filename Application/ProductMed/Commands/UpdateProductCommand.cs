using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProductMed.Commands;

public class UpdateProductCommand (Product instance) : IRequest<IActionResult>
{
    public Product Updated { get; set; } = instance;
}