using System.Collections;
using MediatR;
using MiniMesTrainApi.Application.ParameterMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ParameterMed.Handlers;

public class GetAllParametersHandler : IRequestHandler<GetAllParametersQuery, IEnumerable<Parameter>>
{
   private readonly DatabaseRepo<Parameter> _repo;

   public GetAllParametersHandler(DatabaseRepo<Parameter> repo)
   {
      _repo = repo;
   }

   public async Task<IEnumerable<Parameter>> Handle(GetAllParametersQuery request, CancellationToken token)
   {
      return await _repo.GetAll();
   }
}