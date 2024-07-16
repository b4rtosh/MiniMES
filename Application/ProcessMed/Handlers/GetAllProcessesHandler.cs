using MediatR;
using MiniMesTrainApi.Application.ProcessMed.Queries;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;
using MiniMesTrainApi.Domain.Entities;
namespace MiniMesTrainApi.Application.ProcessMed.Handlers;

public class GetAllProcessesHandler : IRequestHandler<GetAllProcessesQuery, IEnumerable<Process>>
{
    private readonly DatabaseRepo<Domain.Entities.Process> _repo;

    public GetAllProcessesHandler(DatabaseRepo<Process> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Process>> Handle(GetAllProcessesQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}