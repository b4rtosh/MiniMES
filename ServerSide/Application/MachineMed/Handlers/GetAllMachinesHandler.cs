using MediatR;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class GetAllMachinesHandler (DatabaseRepo<Machine> repo) : IRequestHandler<GetAllMachinesQuery, IEnumerable<Machine>>
{
    public async Task<IEnumerable<Machine>> Handle(GetAllMachinesQuery request, CancellationToken token)
    {
        return await repo.GetAll();
    }
    
}
