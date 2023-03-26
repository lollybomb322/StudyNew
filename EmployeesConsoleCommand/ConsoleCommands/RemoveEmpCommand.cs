using EmployeesConsoleCommand.DataController;
using EmployeesConsoleCommand.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    internal class RemoveEmpCommand : IConsoleCommand
    {

        private readonly IConsoleCommand _prevCommand;
        private IDataController _dataController;
        private IServiceProvider _services;

        public RemoveEmpCommand(IConsoleCommand prevCommand, IServiceProvider services)
        {
            _services = services;
            _dataController = services.GetService<IDataController>()!;
            _prevCommand = prevCommand;
        }

        public void Functionality()
        {
            var _list = new GenerateList(_services);
            Print.PrintLogo(LogoEnum.DeleteEmployee);
            if (_list.IsListEmpty())
            {
                Console.WriteLine("\nСотрудников в базе нет!");
                return;
            }
            Console.WriteLine("\tВыберите сотрудника для удаления: \n");
            _list.PrintList();
        }
        public IConsoleCommand Execute(ConsoleKey key)
        {
            var _list = new GenerateList(_services);
            if (!_list.GetList().TryGetValue(key, out Guid guid))
            {
                if (key == ConsoleKey.DownArrow)
                    _list.PageDoun();
                if (key == ConsoleKey.UpArrow)
                    _list.PageUp();
                _list = new GenerateList(_services);
                return this;
            }
            _dataController.Remove(guid);
            return new MainMenuCommand(_services);
        }
        public IConsoleCommand PrevCommand() => _prevCommand;
    }
}
