using System.Collections;
using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Queries;

public class GetAllProcessParamsQuery : IRequest<IEnumerable<ProcessParameter>>
{
}