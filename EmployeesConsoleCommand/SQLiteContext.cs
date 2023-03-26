using Microsoft.EntityFrameworkCore;

namespace EmployeesConsoleCommand.DataController
{
    class SQLiteContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public SQLiteContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/EmployeesDataBase.db");
        }
    }
}
