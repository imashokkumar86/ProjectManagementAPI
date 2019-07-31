using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IManageParentTaskDetails
    {
        Task<IEnumerable<ParentTaskDetail>> GetAll();
        Task<ParentTaskDetail> Get(int id);
        Task<int> Insert(ParentTaskDetail parentTaskDetails);
        Task<int> Edit(ParentTaskDetail parentTaskDetails);
        Task<int> Delete(ParentTaskDetail parentTaskDetails);
    }
}
