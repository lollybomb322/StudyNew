using System.Data;
using Dapper;
using EmployeesConsoleCommand.Enums;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace EmployeesConsoleCommand.DataController
{
    /// <summary>
    /// В процессе разработки, сюда можно не смотреть
    /// </summary>
    class DapperController : IDataController
    {
        string path = "./Data/EmployeesDataBase.db";
        public void Add(Employee emp)
        {
            throw new NotImplementedException();
        }

        public int CountEmployees()
        {
            throw new NotImplementedException();
        }

        public void Edit(Guid guid, string newField, EmployeeFieldsEnum field)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetListEmployee(int startOffset)
        {
            using (IDbConnection db = new SqlConnection(path))
            {
                return db.Query<Employee>($"SELECT * FROM Employees LIMIT 9 OFFSET {startOffset}").ToList();
            }
        }

        public void Remove(Guid guid)
        {
            using (IDbConnection db = new SqlConnection(path))
            {
                db.Query<Employee>($"DELETE FROM Employees WHERE Id = {guid}").ToList();
            }
        }
    }
}
