using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Queries;

public class GetDetailedStatusQuery (int id) : IRequest<ProcessStatus>
{
    public int Id { get; set; } = id;
}