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

        public async Task CreateNew (TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }
        
        public async Task<TEntity?> GetById(long id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbset.ToListAsync();
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
        
        public async Task DelById(int id)
        {
            TEntity entity = await _dbset.FindAsync(id) ?? throw new InvalidOperationException();
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task DelById(long id)
        {
            TEntity entity = await _dbset.FindAsync(id) ?? throw new InvalidOperationException();
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

        public List<int> GetAllIds()
        {
            // get only first column with Ids
            return null;
        }
    }
}