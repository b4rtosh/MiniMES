using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Commands;

public class DeleteProcParamCommand(int id) : IRequest<IActionResult>
{
    public int Id { get; set; } = id;
}