using MediatR;
using MiniMesTrainApi.Domain.Entities;
namespace MiniMesTrainApi.Application.MachineMed.Queries;

public class GetAllMachinesQuery : IRequest<IEnumerable<Machine>>{}