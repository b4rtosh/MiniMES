using MediatR;
using MiniMesTrainApi.Domain.Entities;
namespace MiniMesTrainApi.Application.ProcessMed.Queries;

public class GetAllProcessesQuery : IRequest<IEnumerable<Process>>{}