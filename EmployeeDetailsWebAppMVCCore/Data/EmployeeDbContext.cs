using EmployeeDetailsWebAppMVCCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsWebAppMVCCore.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
