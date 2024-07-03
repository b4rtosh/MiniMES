using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Repositories;

public class DatabaseRepo<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbset;

    public TEntity? GetById(int id)
    {
        return _dbset.Find(id);
    }


    
    
}