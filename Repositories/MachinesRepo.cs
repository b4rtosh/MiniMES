using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;

namespace MiniMesTrainApi.Repositories
{

    public class MachinesRepo(DbContext context) : DatabaseRepo<Machine>
    {
        private readonly DbSet<Machine> _dbset = context.Set<Machine>();
        
        public void CreateNew(string name, string description)
        {
            Machine entity = new()
            {
                Name = name,
                Description = description
            };
            _dbset.Add(entity);
            context.SaveChanges();
        }
    }
}