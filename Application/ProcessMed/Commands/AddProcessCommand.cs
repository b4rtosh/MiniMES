using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessMed.Commands;

public class AddProcessCommand (Process instance) : IRequest<IActionResult>
{
    public Process Instance { get; set; } = instance;
}