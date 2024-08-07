using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ProcessStatusMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessStatusMed.Handlers;

public class GetDetailedStatusHandler (DatabaseRepo<ProcessStatus> repo)
: IRequestHandler<GetDetailedStatusQuery, ProcessStatus>
{
    public async Task<ProcessStatus> Handle(GetDetailedStatusQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetByIdWithIncludes(x => x.Id == request.Id,
            query => query
                .Include(m => m.Processes));
    }
}