using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.MachineMed.Handlers;

public class GetDetailedMachineHandler (DatabaseRepo<Machine> _repo) : IRequestHandler<GetDetailedMachinesQuery, Machine>
{
    public async Task<Machine> Handle(GetDetailedMachinesQuery request, CancellationToken token)
    {
        var machine = await _repo.GetByIdWithIncludes(x => x.Id == request.Id,
            query => query
                .Include(m => m.Orders));
        return machine;
    }
}