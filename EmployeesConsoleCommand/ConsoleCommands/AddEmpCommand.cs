using EmployeesConsoleCommand.DataController;
using EmployeesConsoleCommand.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    internal class AddEmpCommand : IConsoleCommand
    {
        private IConsoleCommand _prevCommand;
        private IDataController _dataController;
        private IServiceProvider _services;
        public AddEmpCommand(IConsoleCommand prevCommand, IServiceProvider services)
        {
            _services = services;
            _dataController = services.GetService<IDataController>()!;
            _prevCommand = prevCommand;
        }
        public IConsoleCommand Execute(ConsoleKey key)
        {
            return new MainMenuCommand(_services);
        }

        public void Functionality()
        {
            Print.PrintLogo(LogoEnum.AddEmployee);
            string? _firstName = Print.InputString("Введите имя нового сотрудника: ");
            if (IsAddCancel(_firstName)) return;
            string? _lastName = Print.InputString("Введите фамилию нового сотрудника: ");
            if (IsAddCancel(_lastName)) return;
            string? _phoneNumber = Print.InputString("Введите номер телефона нового сотрудника: ");
            if (IsAddCancel(_phoneNumber)) return;
            string? _description = Print.InputString("Введите описание нового сотрудника: ");
            if (IsAddCancel(_description)) return;

            var tempEmp = new Employee(Guid.NewGuid(), _firstName!, _lastName!, _phoneNumber!, _description!);


            _dataController.Add(tempEmp);
            Console.WriteLine("\nСотрудник добавлен в базу!\nНажмите любую кнопку для возврата в меню...");
        }
        public IConsoleCommand PrevCommand() => _prevCommand;
        private bool IsAddCancel(string? data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("\nОтмена ввода...\nНажмите любую клавишу для возврата...");
                return true;
            }
            return false;
        }
    }
}
