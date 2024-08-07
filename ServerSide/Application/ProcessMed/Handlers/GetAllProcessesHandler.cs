using MediatR;
using MiniMesTrainApi.Application.ProcessMed.Queries;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;
using MiniMesTrainApi.Domain.Entities;
namespace MiniMesTrainApi.Application.ProcessMed.Handlers;

public class GetAllProcessesHandler (DatabaseRepo<Process> repo) : IRequestHandler<GetAllProcessesQuery, IEnumerable<Process>>
{
    public async Task<IEnumerable<Process>> Handle(GetAllProcessesQuery request, CancellationToken token)
    {
        return await repo.GetAll();
    }
}