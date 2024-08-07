using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.ProcessMed.Commands;

public class DeleteProcessCommand (int id) : IRequest<IActionResult>
{
    public int Id { get; set; } = id;
}