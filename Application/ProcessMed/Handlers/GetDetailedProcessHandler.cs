using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ParameterMed.Queries;
using MiniMesTrainApi.Application.ProcessMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessMed.Handlers;

public class GetDetailedProcessHandler (DatabaseRepo<Process> _repo) : IRequestHandler<GetDetailedProcessQuery, Process>
{
    public async Task<Process> Handle(GetDetailedProcessQuery request, CancellationToken token)
    {
        var process = await _repo.GetByIdWithIncludes(x => x.Id == request.Id,
            query => query
                .Include(m => m.Order)
                .Include(m => m.ProcessStatus)
                .Include(n => n.ProcessParameters)
        );
        return process;
    }
}