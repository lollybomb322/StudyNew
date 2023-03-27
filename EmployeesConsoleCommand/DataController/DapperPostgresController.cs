using System.Data;
using EmployeesConsoleCommand.Enums;
using Npgsql;
using Dapper;

namespace EmployeesConsoleCommand.DataController
{
    class DapperPostgresController : IDataController
    {
        private string _connection = "Server=localhost;Port=5432;Database=Employees;User Id=admin;Password=root;";


        public void Add(Employee emp)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                connection.Execute($"INSERT INTO Employees VALUES ('{emp.Id}', '{emp.FirstName}', '{emp.LastName}', '{emp.PhoneNumber}', '{emp.Description}')");
            }
        }

        public int CountEmployees()
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                int a = connection.QueryFirstOrDefault<int>($"SELECT COUNT(*) FROM Employees");
                return a;
            }
        }

        public void Edit(Guid guid, string newField, EmployeeFieldsEnum field)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                connection.Execute($"UPDATE Employees SET {field.ToString().ToLower()} = '{newField}' WHERE id = '{guid}'");
            }
        }

        public Employee GetEmployeeById(Guid guid)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Employee>($"SELECT * FROM Employees Where id = '{guid}'");
            }
        }

        public List<Employee> GetListEmployee(int startOffset)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                connection.Open();
                var qwe = connection.Query<Employee>($"SELECT * FROM Employees LIMIT 9 OFFSET {startOffset}").ToList();
                return qwe;
            }
        }

        public void Remove(Guid guid)
        {
            using (IDbConnection db = new NpgsqlConnection(_connection))
            {
                db.Open();
                db.Query<Employee>($"DELETE FROM Employees WHERE Id = '{guid}'");
            }
        }
    }
}
