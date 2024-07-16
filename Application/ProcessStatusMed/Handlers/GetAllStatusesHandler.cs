using System.Collections;
using MediatR;
using MiniMesTrainApi.Application.ProcessStatusMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Handlers;

public class GetAllStatusesHandler : IRequestHandler<GetAllStatusesQuery, IEnumerable<ProcessStatus>>
{
    private readonly DatabaseRepo<ProcessStatus> _repo;

    public GetAllStatusesHandler(DatabaseRepo<ProcessStatus> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProcessStatus>> Handle(GetAllStatusesQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}