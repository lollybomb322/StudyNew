using EmployeesConsoleCommand.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeesConsoleCommand.DataController
{
    class SQLiteController : IDataController
    {
       
        public void Add(Employee emp)
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                db.Employees?.Add(emp);
                db.SaveChanges();
            }
        }

        public int CountEmployees()
        {
            using (SQLiteContext db = new SQLiteContext()) 
                return db.Employees.Count(); 
        }

        public void Edit(Guid guid, string newField, EmployeeFieldsEnum field)
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                switch (field)
                {
                    case EmployeeFieldsEnum.FirstName:
                        db.Employees.FirstOrDefault(x => x.Id == guid)!.FirstName = newField;
                        break;
                    case EmployeeFieldsEnum.LastName:
                        db.Employees.FirstOrDefault(x => x.Id == guid)!.LastName = newField;
                        break;
                    case EmployeeFieldsEnum.PhoneNumber:
                        db.Employees.FirstOrDefault(x => x.Id == guid)!.PhoneNumber = newField;
                        break;
                    case EmployeeFieldsEnum.Description:
                        db.Employees.FirstOrDefault(x => x.Id == guid)!.Description = newField;
                        break;
                }
                db.SaveChanges();
            }
        }

        public Employee GetEmployeeById(Guid id)
        {
            using(SQLiteContext db = new SQLiteContext())
                return db.Employees.First(x => x.Id == id);
        }
        public List<Employee> GetListEmployee(int startOffset)
        {
            using (SQLiteContext db = new SQLiteContext())
                return db.Employees.FromSqlRaw($"SELECT * FROM Employees LIMIT 9 OFFSET {startOffset}").ToList();
        }


        public void Remove(Guid guid)
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                Employee emp = db.Employees.FirstOrDefault(x => x.Id == guid)!;
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
    }
}
