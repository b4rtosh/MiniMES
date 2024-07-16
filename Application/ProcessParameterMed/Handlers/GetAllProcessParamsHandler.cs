using System.Collections;
using MediatR;
using MiniMesTrainApi.Application.ProcessParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProcessParameterMed.Handlers;

public class GetAllProcessParamsHandler : IRequestHandler<GetAllProcessParamsQuery, IEnumerable<ProcessParameter>>
{
    private readonly DatabaseRepo<ProcessParameter> _repo;

    public GetAllProcessParamsHandler(DatabaseRepo<ProcessParameter> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProcessParameter>> Handle(GetAllProcessParamsQuery request, CancellationToken token)
    {
        return await _repo.GetAll();
    }
}