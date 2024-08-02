using System.Collections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class GetAllProcessParamsHandler(DatabaseRepo<ProcessParameter> _repo)
    : IRequestHandler<GetAllProcParamsQuery, IEnumerable<ProcessParameter>>
{   
    public async Task<IEnumerable<ProcessParameter>> Handle(GetAllProcParamsQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}