using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;

namespace Task_Management.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext>Options) :base(Options)
        {

        }
        public  DbSet<User> tblUser { get; set; }  
        public DbSet<Employee> tblemployee { get; set; }
        public DbSet<TaskItem> tbltaskItem { get; set; }
        public DbSet<Status> tblstatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User{  UserId = 1,Name = "PM1",Email ="pm@gmail.com",Password = "123",Role = "Project Manager" },
             new User  { UserId = 2, Name = "Employee1", Email = "emp@gmail.com", Password = "1234", Role = "Employee" }

                );
            
            modelBuilder.Entity<Status>().HasData(
                new Status { SID = 1, status = "pending" },
                new Status { SID = 2, status = "complete" }
            );
        }
    }
}
