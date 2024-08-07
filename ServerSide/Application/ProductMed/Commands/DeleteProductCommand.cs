using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.ProductMed.Commands;

public class DeleteProductCommand (int id) : IRequest<IActionResult>
{
    public int Id { get; set; } = id;
}