using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add initial seed data
            LoadSeedData(modelBuilder);
        }

        public void LoadSeedData(ModelBuilder modelBuilder)
        {
            // Load Roles and Rates
            modelBuilder.Entity<Role>().HasData(
                 new Role { RoleID = -1, RoleName = "Manager", RoleRate = 100 },
                 new Role { RoleID = 1, RoleName = "Casual Employee Level 1", RoleRate = 50 },
                 new Role { RoleID = 2, RoleName = "Casual Employee Level 2", RoleRate = 75 });

            // Load Employees
            modelBuilder.Entity<Employee>().HasData(
                 new Employee
                 {
                     EmployeeID = 1,
                     EmployeeName = "Jaques",
                     EmployeeSurname = "Greyling",
                     EmployeeEmail = "jaquesg@company.co.za",
                     EmployeePassword = "1234",
                     EmployeeImage = null,
                     EmployeeStartDate = DateTime.Now,
                     EmployeeEndDate = DateTime.Now.AddDays(7),
                     RoleID = 1
                 },

                 new Employee
                 {
                     EmployeeID = 2,
                     EmployeeName = "Johan",
                     EmployeeSurname = "Rogers",
                     EmployeeEmail = "johanr@company.co.za",
                     EmployeePassword = "qwer",
                     EmployeeImage = null,
                     EmployeeStartDate = DateTime.Now,
                     EmployeeEndDate = DateTime.Now.AddDays(7),
                     RoleID = 2
                 },

                  new Employee
                  {
                      EmployeeID = 3,
                      EmployeeName = "Stacy",
                      EmployeeSurname = "Smith",
                      EmployeeEmail = "stacys@company.co.za",
                      EmployeePassword = "q1w2e3",
                      EmployeeImage = null,
                      EmployeeStartDate = DateTime.Now,
                      EmployeeEndDate = DateTime.Now.AddDays(7),
                      RoleID = -1
                  });

            // Load Tasks
            modelBuilder.Entity<Task>().HasData(
                 new Task { TaskID = 1, TaskName = "Create DB", TaskDesc = "Create DB according to specification", TaskDuration = 5},
                 new Task { TaskID = 2, TaskName = "Create API", TaskDesc = "Create API according to specification", TaskDuration = 4 },
                 new Task { TaskID = 3, TaskName = "Create UI", TaskDesc = "Create UI according to specification", TaskDuration = 4 });
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ActiveTask> ActiveTasks { get; set; }
    }
}
