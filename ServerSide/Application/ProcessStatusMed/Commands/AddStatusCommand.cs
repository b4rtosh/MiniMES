using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Commands;

public class AddStatusCommand (ProcessStatus instance) : IRequest<IActionResult>
{
    public ProcessStatus Instance { get; set; } = instance;
}