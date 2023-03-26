using EmployeesConsoleCommand.Enums;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    class MainMenuCommand : IConsoleCommand
    {
        private readonly Dictionary<ConsoleKey, IConsoleCommand> _supportNextCommand;
        public MainMenuCommand(IServiceProvider services)
        {
            _supportNextCommand = new Dictionary<ConsoleKey, IConsoleCommand>()
            {
                { ConsoleKey.D1, new ViewAllEmpCommand(this, services) },
                { ConsoleKey.D2, new AddEmpCommand(this, services) },
                { ConsoleKey.D3, new RemoveEmpCommand(this, services) }
            };
        }
        public void Functionality()
        {
            Print.PrintLogo(LogoEnum.Welcome);
            Print.PrintPointsMenu(new string[] { "Список сотрудников", "Добавить сотрудника", "Удалить сотрудника" });
        }
        public IConsoleCommand Execute(ConsoleKey key)
        {
            if (!_supportNextCommand.TryGetValue(key, out var command))
            {
                return this;
            }
            return command;
        }

        public IConsoleCommand PrevCommand() => this;
    }
}
