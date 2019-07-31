using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess
{
    public class ProjectManagerApiDbContext : DbContext
    {
        public ProjectManagerApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<TaskDetail> Tasks { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Entities.ParentTaskDetail> ParentTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
            optionsBuilder.EnableSensitiveDataLogging();          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
      builder.Entity<Entities.ParentTaskDetail>().HasKey("ParentId");
            builder.Entity<Entities.ParentTaskDetail>().ToTable("ParentTask");
      builder.Entity<Entities.ParentTaskDetail>().Property(p => p.ParentId).ValueGeneratedOnAdd().HasColumnName("Parent_ID").IsRequired(); 
      builder.Entity<Entities.ParentTaskDetail>().Property(p => p.ParentTask).HasColumnName("Parent_Task").IsRequired().HasMaxLength(200);

            builder.Entity<User>().HasKey("UserId").HasName("User_ID");
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().Property(t => t.FirstName).HasColumnName("First_Name").IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(t => t.LastName).HasColumnName("Last_Name").IsRequired().HasMaxLength(100); ;
            builder.Entity<User>().Property(t => t.EmployeeId).HasColumnName("Employee_ID").IsRequired();
            builder.Entity<User>().Property(t => t.UserId).ValueGeneratedOnAdd().HasColumnName("User_ID").IsRequired();

            builder.Entity<Project>().HasKey("ProjectId");
            builder.Entity<Project>().ToTable("Project");
            builder.Entity<Project>().Property(t => t.ProjectName).HasColumnName("Project_Name").IsRequired().HasMaxLength(100);
            builder.Entity<Project>().Property(t => t.StartDate).HasColumnName("Start_Date");
            builder.Entity<Project>().Property(t => t.EndDate).HasColumnName("End_Date");
            builder.Entity<Project>().Property(t => t.Priority).IsRequired();
            builder.Entity<Project>().Property(t => t.ActiveStatus).HasColumnName("Status").IsRequired();
            builder.Entity<Project>().Property(t => t.ProjectId).ValueGeneratedOnAdd().HasColumnName("Project_ID").IsRequired();
            builder.Entity<Project>().Property(t => t.UserId).HasColumnName("User_ID");
            builder.Entity<Project>().HasOne(t => t.UserDetail).WithMany(u => u.Projects).HasForeignKey(t => t.UserId);

            builder.Entity<TaskDetail>().HasKey("Id");
            builder.Entity<TaskDetail>().ToTable("Task");
            builder.Entity<TaskDetail>().Property(t => t.Name).HasColumnName("Task_Name").IsRequired().HasMaxLength(100);
            builder.Entity<TaskDetail>().Property(t => t.StartDate).HasColumnName("Start_Date");
            builder.Entity<TaskDetail>().Property(t => t.EndDate).HasColumnName("End_Date");
            builder.Entity<TaskDetail>().Property(t => t.ParentId).HasColumnName("Parent_ID");
            builder.Entity<TaskDetail>().Property(t => t.Priority).IsRequired();
            builder.Entity<TaskDetail>().Property(t => t.ActiveStatus).HasColumnName("Status").IsRequired();
            builder.Entity<TaskDetail>().Property(t => t.Id).ValueGeneratedOnAdd().HasColumnName("Task_ID").IsRequired();
            builder.Entity<TaskDetail>().Property(t => t.UserId).HasColumnName("User_ID");
            builder.Entity<TaskDetail>().Property(t => t.ProjectId).HasColumnName("Project_ID");
            builder.Entity<TaskDetail>().HasOne(t => t.UserDetail).WithMany(u => u.TaskDetails).HasForeignKey(t => t.UserId);
            builder.Entity<TaskDetail>().HasOne(t => t.ProjectDetail).WithMany(u => u.TaskDetails).HasForeignKey(t => t.ProjectId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TaskDetail>().HasOne(t => t.ParentTask).WithMany(u => u.TaskDetails).HasForeignKey(t => t.ParentId).OnDelete(DeleteBehavior.Restrict);

    }       
    }
}
