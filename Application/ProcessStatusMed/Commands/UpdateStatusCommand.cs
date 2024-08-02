using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Commands;

public class UpdateStatusCommand (ProcessStatus updated) : IRequest<IActionResult>
{
    public ProcessStatus Updated { get; set; } = updated;
}