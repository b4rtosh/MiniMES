using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.MachineMed.Commands;

public class UpdateMachineCommand : IRequest<IActionResult>
{
    public Machine Updated { get; set; }
    public UpdateMachineCommand(Machine updated)
    {
        Updated = updated;
    }

}