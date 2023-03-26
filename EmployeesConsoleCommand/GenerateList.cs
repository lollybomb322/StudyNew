using EmployeesConsoleCommand.ConsoleCommands;
using EmployeesConsoleCommand.DataController;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesConsoleCommand
{
    internal class GenerateList
    {
        /// <summary>
        /// класс должен иметь публичные методы для смены страницы, метод печати списка, 
        /// метод получения словаря
        /// </summary>
        private List<string> _pointsMenu = new();
        private Dictionary<ConsoleKey, Guid> _result = new();
        private IDataController _dataController;
        private static (int, int) _pages = (1, 0);
        public GenerateList(IServiceProvider serviceProvider)
        {
            _dataController = serviceProvider.GetService<IDataController>() ?? throw new Exception("Ошибка GenerateList");
            MathPages();
        }
        public void PrintList()
        {
            MathList();
            if (_pages.Item2 > 0)
                Print.PrintPointsMenu(_pointsMenu);
            if (_pages.Item2 > 1)
                Console.WriteLine($"\n\tТекущая страница [{_pages.Item1}/{_pages.Item2}]\n\tНажимайте стрелки ВВЕРХ/ВНИЗ для переключения страниц");
        }
        public Dictionary<ConsoleKey, Guid> GetList()
        {
            MathList();
            return _result;
        }

        private void MathList()
        {
            _pointsMenu = new();
            _result = new();
            MathPages();
            if (_pages.Item1 == 0)
                return;
            int startInt = _pages.Item1 * 9 - 9;
            var employees = _dataController.GetListEmployee(startInt);
            for (int i = 0; i < employees.Count; i++)
            {
                _result.Add((ConsoleKey)i + 49, employees[i].Id);
                _pointsMenu.Add($"{employees[i].LastName} {employees[i].FirstName}");
            }
        }
        private void MathPages()
        {
            int countEmp = _dataController.CountEmployees();
            if (countEmp == 0) { _pages = (0, 0); return; }
            if (countEmp <= 9) { _pages = (1, 1); return; }
            _pages.Item2 = (int)Math.Ceiling((decimal)countEmp / 9);

            if (_pages.Item2 < _pages.Item1) 
                _pages.Item1--;
        }

        public void PageUp()
        {
            if (_pages.Item1 != 1)
                _pages.Item1--;
        }
        public void PageDoun()
        {
            if (_pages.Item1 < _pages.Item2)
                _pages.Item1++;
        }
        public bool IsListEmpty() => _pages.Item2 == 0;
    }
}
