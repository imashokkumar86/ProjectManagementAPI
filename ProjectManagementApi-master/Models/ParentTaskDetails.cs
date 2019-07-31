using System.Collections.Generic;

namespace Entities
{
    public partial class ParentTaskDetail
    {
        public int ParentId { get; set; }
        public string ParentTask { get; set; }
    public IList<TaskDetail> TaskDetails { get; set; }
  }
}
