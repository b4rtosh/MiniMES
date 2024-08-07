using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessMed.Queries;

public class GetDetailedProcessQuery (int id) : IRequest<Process>
{
    public int Id { get; set; } = id;
}