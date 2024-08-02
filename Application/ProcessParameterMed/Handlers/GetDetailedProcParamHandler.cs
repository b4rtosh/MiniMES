using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Application.ProductMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class GetDetailedProcParamHandler (DatabaseRepo<ProcessParameter> _repo) 
    : IRequestHandler<GetDetailedProcParamQuery, ProcessParameter>
{
    public async Task<ProcessParameter> Handle(GetDetailedProcParamQuery request, CancellationToken token)
    {
        var processParam = await _repo.GetByIdWithIncludes(x => x.Id == request.Id, 
            query => query
                .Include(x => x.Process)
                .Include(x => x.Parameter));
        return processParam;
    } }