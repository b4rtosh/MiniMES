using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;

namespace MiniMesTrainApi.Repositories
{

    public class MachinesRepo : Machine
    {
        private readonly DbContext _context;    
        private readonly DbSet<Machine> _dbset;

        public MachinesRepo(DbContext context)
        {
            _context = context;
            _dbset = context.Set<Machine>();
        }
        public void CreateNew(string name, string description)
        {
            Machine entity = new()
            {
                Name = name,
                Description = description
            };
            _dbset.Add(entity);
            _context.SaveChanges();
        }
    }
}