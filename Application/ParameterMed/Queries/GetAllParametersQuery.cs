using System.Collections;
using MediatR;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.ParameterMed.Queries;

public class GetAllParametersQuery : IRequest<IEnumerable<Parameter>>{}
