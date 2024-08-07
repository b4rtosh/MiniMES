using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ParameterMed.Commands;

public class UpdateParamCommand (Parameter updated) : IRequest<IActionResult>
{
    public Parameter Updated { get; set; } = updated;
}