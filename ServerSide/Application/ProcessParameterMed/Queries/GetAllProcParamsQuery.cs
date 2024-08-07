using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Queries;

public class GetAllProcParamsQuery : IRequest<IEnumerable<ProcessParameter>>
{
}