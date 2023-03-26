using EmployeesConsoleCommand.DataController;
using EmployeesConsoleCommand.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    internal class EditEmpCommand : IConsoleCommand
    {
        private readonly IConsoleCommand _prevCommand;
        private readonly IDataController _dataController;
        private readonly IServiceProvider _services;
        private Guid _guid;
        private EmployeeFieldsEnum _dataEmployee;
        public EditEmpCommand(IConsoleCommand prevCommand, Guid guid, EmployeeFieldsEnum dataEmployee, IServiceProvider services)
        {
            _services = services;
            _dataController = services.GetService<IDataController>()!;
            _prevCommand = prevCommand;
            _dataEmployee = dataEmployee;
            _guid = guid;
        }
        public void Functionality()
        {
            Print.PrintLogo(LogoEnum.EditEmployee);
            string? temp = _dataEmployee switch
            {
                EmployeeFieldsEnum.FirstName => Print.InputString("Введите новое имя сотрудника: "),
                EmployeeFieldsEnum.LastName => Print.InputString("Введите новую фамилию сотрудника: "),
                EmployeeFieldsEnum.PhoneNumber => Print.InputString("Введите новый номер телефона сотрудника: "),
                EmployeeFieldsEnum.Description => Print.InputString("Введите новое описание сотрудника: "),
                _ => null
            };
            if (string.IsNullOrWhiteSpace(temp))
            {
                Console.WriteLine("\nОтмена ввода...\nНажмите любую клавишу для возврата...");
                return;
            }
            Console.WriteLine("\nДанные сотрудника отредактированы!\nНажмите любую клавишу для возврата...");
            _dataController.Edit(_guid, temp, _dataEmployee);
        }
        public IConsoleCommand Execute(ConsoleKey key) => new ProfileEmpCommand(_prevCommand, _services, _guid);
        

        public IConsoleCommand PrevCommand() => _prevCommand;
    }
}
