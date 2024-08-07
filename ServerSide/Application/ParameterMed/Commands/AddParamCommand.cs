
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ParameterMed.Commands;

public class AddParamCommand(Parameter instance) : IRequest<IActionResult>
{
    public Parameter Instance { get; set; } = instance;
}