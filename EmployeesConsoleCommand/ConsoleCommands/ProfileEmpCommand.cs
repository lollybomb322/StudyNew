using EmployeesConsoleCommand.DataController;
using EmployeesConsoleCommand.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    internal class ProfileEmpCommand : IConsoleCommand
    {
        private Dictionary<ConsoleKey, IConsoleCommand> _supportNextCommand;
        private readonly IConsoleCommand _prevCommand;
        private readonly IDataController _dataController;
        private readonly Employee _currentEmployee;
        public ProfileEmpCommand(IConsoleCommand prevCommand, IServiceProvider services, Guid guid)
        {
            _dataController = services.GetService<IDataController>()!;
            _prevCommand = prevCommand;
            _currentEmployee = _dataController.GetEmployeeById(guid);

            _supportNextCommand = new Dictionary<ConsoleKey, IConsoleCommand>()
            {
                { ConsoleKey.D1, new EditEmpCommand(prevCommand, guid, EmployeeFieldsEnum.FirstName, services) },
                { ConsoleKey.D2, new EditEmpCommand(prevCommand, guid, EmployeeFieldsEnum.LastName, services) },
                { ConsoleKey.D3, new EditEmpCommand(prevCommand, guid, EmployeeFieldsEnum.PhoneNumber, services) },
                { ConsoleKey.D4, new EditEmpCommand(prevCommand, guid, EmployeeFieldsEnum.Description, services) }
            };
        }
        public void Functionality()
        {
            Print.PrintLogo(LogoEnum.EmployeeProfile);
            Console.WriteLine(
            @$"
[1] Имя: {_currentEmployee.FirstName}
[2] Фамилия: {_currentEmployee.LastName}
[3] Телефон: {_currentEmployee.PhoneNumber}
[4] Описание: {_currentEmployee.Description}

Для редактирования данных нажмите соответствующую клавишу...
");
        }
        public IConsoleCommand Execute(ConsoleKey key)
        {
            if (!_supportNextCommand.TryGetValue(key, out var command))
            {
                return this;
            }
            return command;
        }

        public IConsoleCommand PrevCommand() => _prevCommand;

    }
}
