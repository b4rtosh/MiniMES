using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProductMed.Commands;

public class AddProductCommand (Product instance) : IRequest<IActionResult>
{
    public Product Instance { get; set; } = instance;
}