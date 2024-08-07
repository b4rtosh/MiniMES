using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Commands;

public class AddProcParamCommand (ProcessParameter instance) : IRequest<IActionResult>
{
    public ProcessParameter Instance { get; set; } = instance;
    
}