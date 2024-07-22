using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Domain.Entities;

namespace MiniMesTrainApi.Application.MachineMed.Queries;

public class GetDetailedMachinesQuery : IRequest<Machine>
{
    public int Id { get; set; }
    public GetDetailedMachinesQuery(int id)
    {
        Id = id;
    }
}