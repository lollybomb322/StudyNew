using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesConsoleCommand.Enums;

namespace EmployeesConsoleCommand.DataController
{
    internal interface IDataController
    {
        public List<Employee> GetListEmployee(int startOffset);
        public int CountEmployees();
        public Employee GetEmployeeById(Guid guid);
        public void Add(Employee emp);
        public void Remove(Guid guid);
        public void Edit(Guid guid, string newField, EmployeeFieldsEnum field);
    }
}
