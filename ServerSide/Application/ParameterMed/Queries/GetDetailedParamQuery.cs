using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ParameterMed.Queries;

public class GetDetailedParamQuery (int id) : IRequest<Parameter>
{
    public int Id { get; set; } = id;
}