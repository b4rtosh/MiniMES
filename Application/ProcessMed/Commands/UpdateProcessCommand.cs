using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessMed.Commands;

public class UpdateProcessCommand (Process updated) : IRequest<IActionResult>
{
    public Process Updated { get; set; } = updated;
}