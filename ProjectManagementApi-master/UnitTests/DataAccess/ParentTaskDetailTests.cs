using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.DataAccess.Helpers;
using Xunit;

namespace UnitTests.DataAccess
{
    public class ParentTaskDetailTests
    {
        DbContextOptions<ProjectManagerApiDbContext> contextOptions;

      public  ParentTaskDetailTests()
        {
            contextOptions = new DbContextOptions<ProjectManagerApiDbContext>();
        }

        [Fact]
        public async Task ToVerifyParentTaskDetailCountThrowException()
        {
         
            var mockContext = new Mock<ProjectManagerApiDbContext>(contextOptions);
           
            var parentTaskRepository = new global::DataAccess.ParentTaskDetail(mockContext.Object);

      IQueryable<Entities.ParentTaskDetail> parentTaskDetailsList = TestData.GetParentTaskDetails().AsQueryable();

            var mockSet = new Mock<DbSet<TaskDetail>>();

            mockSet.As<IAsyncEnumerable<Entities.ParentTaskDetail>>()
        .Setup((IAsyncEnumerable<Entities.ParentTaskDetail> m) => m.GetEnumerator())
        .Returns(new TestAsyncEnumerator<Entities.ParentTaskDetail>(parentTaskDetailsList.GetEnumerator()));

            mockSet.As<IQueryable<Entities.ParentTaskDetail>>()
                .Setup((IQueryable<Entities.ParentTaskDetail> m) => m.Provider)
                .Returns(new TestAsyncQueryProvider<Entities.ParentTaskDetail>(parentTaskDetailsList.Provider));

            mockSet.As<IQueryable<Entities.ParentTaskDetail>>().Setup((IQueryable<Entities.ParentTaskDetail> m) => m.Expression).Returns(parentTaskDetailsList.Expression);
            mockSet.As<IQueryable<Entities.ParentTaskDetail>>().Setup((IQueryable<Entities.ParentTaskDetail> m) => m.ElementType).Returns(parentTaskDetailsList.ElementType);
            mockSet.As<IQueryable<Entities.ParentTaskDetail>>().Setup((IQueryable<Entities.ParentTaskDetail> m) => m.GetEnumerator()).Returns(() => parentTaskDetailsList.GetEnumerator());

            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            
            await Assert.ThrowsAsync<System.NotImplementedException>(()=>  parentTaskRepository.GetAll());
        }
    }
}
