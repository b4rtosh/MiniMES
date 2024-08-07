using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Application.ParameterMed.Commands;

public class DeleteParamCommand(int id) : IRequest<IActionResult>
{
    public int Id { get; set; } = id;
}