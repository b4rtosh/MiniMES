using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.MachineMed.Commands;

public class AddMachineCommand : IRequest<IActionResult>
{
    public Machine Instance { get; set; }
    public AddMachineCommand(Machine instance)
    {
        Instance = instance;
    }
}