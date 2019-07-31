using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess
{
    public class ParentTaskDetail : IParentTaskDetails
    {
        private readonly ProjectManagerApiDbContext _dbContext;
        public ParentTaskDetail()
        {
        }

    public async Task SaveDabaseChanges()
    {
      await _dbContext.SaveChangesAsync();
    }
    public ParentTaskDetail(ProjectManagerApiDbContext dbContext)
        {
            _dbContext = dbContext;          
        }       
        public async Task<IEnumerable<Entities.ParentTaskDetail>> GetAll()
        {
      return await _dbContext.ParentTasks.AsNoTracking().ToListAsync();
    }
        public async Task<Entities.ParentTaskDetail> Get(int id)
        {
      return await _dbContext.ParentTasks.AsNoTracking().FirstOrDefaultAsync(t => t.ParentId == id);
    }
        public async Task<int> Insert(Entities.ParentTaskDetail parentTaskDetails)
        {
      _dbContext.ParentTasks.Add(parentTaskDetails);
      return await _dbContext.SaveChangesAsync();
    }
        public async Task<int> Edit(Entities.ParentTaskDetail parentTaskDetails)
        {
      _dbContext.ParentTasks.Update(parentTaskDetails);
      return await _dbContext.SaveChangesAsync();
    }
        public async Task<int> Delete(Entities.ParentTaskDetail parentTaskDetails)
        {
      _dbContext.ParentTasks.Remove(parentTaskDetails);
      return await _dbContext.SaveChangesAsync();
    }
    }
}
