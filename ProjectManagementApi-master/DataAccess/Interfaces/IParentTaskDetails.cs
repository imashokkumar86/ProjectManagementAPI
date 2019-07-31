using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IParentTaskDetails
    {
        Task<IEnumerable<Entities.ParentTaskDetail>> GetAll();
        Task<Entities.ParentTaskDetail> Get(int id);
        Task<int> Insert(Entities.ParentTaskDetail parentTaskDetails);
        Task<int> Edit(Entities.ParentTaskDetail parentTaskDetails);
        Task<int> Delete(Entities.ParentTaskDetail parentTaskDetails);
    }
}
