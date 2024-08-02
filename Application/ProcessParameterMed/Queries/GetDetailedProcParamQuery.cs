using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Queries;

public class GetDetailedProcParamQuery (int id) : IRequest<ProcessParameter>
{
    public int Id { get; set; } = id;
}