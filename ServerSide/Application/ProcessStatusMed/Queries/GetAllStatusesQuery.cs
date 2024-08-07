using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Queries;

public class GetAllStatusesQuery : IRequest<IEnumerable<ProcessStatus>>{}