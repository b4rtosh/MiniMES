using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ParameterMed.Handlers;

public class GetDetailedParamHandler (DatabaseRepo<Parameter> repo) : IRequestHandler<GetDetailedParamQuery, Parameter>
{
    public async Task<Parameter> Handle(GetDetailedParamQuery request, CancellationToken cancellationToken)
    {
        var parameter = await repo.GetByIdWithIncludes(x => x.Id == request.Id,
            query => query
                .Include(m => m.ProcessParameters));
        return parameter;
    }
}