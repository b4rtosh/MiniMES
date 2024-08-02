using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Application.OrderMed.Queries;
using MiniMesTrainApi.Application.ProductMed.Queries;
using MiniMesTrainApi.Domain.Entities;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Application.ProductMed.Handlers;

public class GetDetailedProductHandler (DatabaseRepo<Product> _repo) : IRequestHandler<GetDetailedProductQuery, Product>
{
    public async Task<Product> Handle(GetDetailedProductQuery request, CancellationToken token)
    {
        var product = await _repo.GetByIdWithIncludes(x => x.Id == request.Id, 
            query => query
                .Include(m => m.Orders));
        return product;
    } }