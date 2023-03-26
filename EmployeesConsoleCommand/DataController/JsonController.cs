using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeesConsoleCommand.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeesConsoleCommand.DataController
{
    class JsonController : IDataController
    {
        public void Add(Employee emp)
        {
            List<Employee> list = GetAllEmployees();
            list.Add(emp);
            PushData(list);
        }
        public void Remove(Guid guid)
        {
            List<Employee> list = GetAllEmployees();
            if (list != null && list.Count > 0)
            {
                list.Remove(list.Find(x => x.Id == guid)!);
                PushData(list);
            }
        }
        public void Edit(Guid guid, string newField, EmployeeFieldsEnum field)
        {
            List<Employee> list = GetAllEmployees();
            switch (field)
            {
                case EmployeeFieldsEnum.FirstName:
                    list.Find(x => x.Id == guid)!.FirstName = newField;
                    break;
                case EmployeeFieldsEnum.LastName:
                    list.Find(x => x.Id == guid)!.LastName = newField;
                    break;
                case EmployeeFieldsEnum.PhoneNumber:
                    list.Find(x => x.Id == guid)!.PhoneNumber = newField;
                    break;
                case EmployeeFieldsEnum.Description:
                    list.Find(x => x.Id == guid)!.Description = newField;
                    break;
            }
            PushData(list);
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee>? employees = new();
            try
            {
                employees = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText("./Data/EmployeesDataBase.json"));
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Отсутствует файл базы сотрудников!\n\n" + ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Отсутствует файл базы сотрудников!\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неизвестная ошибка!\n\n" + ex.Message);
            }
            
            return employees == null ? new() : employees;
        }
        private void PushData(List<Employee> employees)
        {
            File.WriteAllText("./Data/EmployeesDataBase.json", JsonSerializer.Serialize(employees));
        }

        public List<Employee> GetListEmployee(int startOffset)
        {
            var employees = GetAllEmployees();
            return employees.Skip(startOffset).Take(9).ToList();
        }

        public bool? IsPagesNeed()
        {
            var employees = GetAllEmployees();
            if (employees.Count == 0) return null;
            if (employees.Count <= 9) return false;
            return true;
        }

        public int CountEmployees() => GetAllEmployees().Count();

        public Employee GetEmployeeById(Guid id) => GetAllEmployees().Find(x => x.Id == id)!;
    }
}
