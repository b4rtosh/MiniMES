using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Repositories
{
    public class DatabaseRepo<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbset;


        public DatabaseRepo(DbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public DbContext GetContext()
        {
            return _context;
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

        public async Task<TEntity> GetByIdWithIncludes(
            Expression<Func<TEntity, bool>>? conditions = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? queries = null)
        {
            try
            {
                var query = _dbset.AsNoTracking().AsQueryable();
 
                if (conditions != null) query = query.Where(conditions);
                if (queries != null) query = queries(query);
                string temp = query.ToQueryString();
                var result = await query.SingleOrDefaultAsync();
 
                if (result == null)
                {
                    return null;
                }
 
                return result;
            }
            catch (Exception ex)
            {
                return null;//maybe handle it better?
            }
        }

        // public async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        // {
        //     IQueryable<TEntity> query = _dbset;
        //
        //     foreach (var include in includes)
        //     {
        //         query = query.Include(include);
        //     }
        //
        //     return await query.SingleOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        // }

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
}