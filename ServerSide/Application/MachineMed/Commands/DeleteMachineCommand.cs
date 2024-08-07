using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.MachineMed.Commands;

public class DeleteMachineCommand : IRequest<IActionResult>
{
    public int Id { get; set; }
    public DeleteMachineCommand(int id)
    {
        Id = id;
    }
}