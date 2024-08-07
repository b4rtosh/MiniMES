using MediatR;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class GetAllProcessParamsHandler(DatabaseRepo<ProcessParameter> repo)
    : IRequestHandler<GetAllProcParamsQuery, IEnumerable<ProcessParameter>>
{   
    public async Task<IEnumerable<ProcessParameter>> Handle(GetAllProcParamsQuery request, CancellationToken token)
    {
        return await repo.GetAll();
    }
}