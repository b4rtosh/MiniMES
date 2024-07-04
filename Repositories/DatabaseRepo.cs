using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Repositories;

public class DatabaseRepo<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbset;


    public DatabaseRepo(DbContext context)
    {
        _context = context;
        _dbset = context.Set<TEntity>();
    }

    public void CreateNew(TEntity entity)
    {
        _dbset.Add(entity);
        _context.SaveChanges();
    }

    public TEntity? GetById(int id)
    {
        return _dbset.Find(id);
    }


    public List<TEntity> GetAll()
    {
        return _dbset.ToList();
    }

    public void DelById(int id)
    {
        _dbset.Remove(GetById(id));
        _context.SaveChanges();
    }


    public void Update(TEntity entity)
    {
        _dbset.Update(entity);
        _context.SaveChanges();
    }

    public List<int> GetAllIds()
    {
        // get only first column with Ids
        return null;
    }
}