using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Commands;

public class DeleteStatusCommand (int id) : IRequest<IActionResult>
{
    public int Id { get; set; } = id;
}