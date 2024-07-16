using System.Collections;
using MediatR;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class GetAllMachinesHandler : IRequestHandler<GetAllMachinesQuery, IEnumerable<Machine>>
{
    private readonly DatabaseRepo<Machine> _repo;

    public GetAllMachinesHandler(DatabaseRepo<Machine> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Machine>> Handle(GetAllMachinesQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
    
}
