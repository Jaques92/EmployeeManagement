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
            modelBuilder.Entity<ActiveTask>(at =>
                {
                    at.HasNoKey();
                });

            //Add initial seed data
            LoadSeedData(modelBuilder);
        }

        public void LoadSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                 new Role { RoleID = -1, RoleName = "Manager", RoleRate = 100 },
                 new Role { RoleID = 1, RoleName = "Casual Employee Level 1", RoleRate = 50 },
                 new Role { RoleID = 2, RoleName = "Casual Employee Level 2", RoleRate = 75 });
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ActiveTask> ActiveTasks { get; set; }
    }
}
