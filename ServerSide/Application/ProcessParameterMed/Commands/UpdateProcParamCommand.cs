using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Commands;

public class UpdateProcParamCommand (ProcessParameter instance) : IRequest<IActionResult>
{
    public ProcessParameter Updated { get; set; } = instance;
}