using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesConsoleCommand.ConsoleCommands
{
    internal interface IConsoleCommand
    {
        void Functionality();
        IConsoleCommand Execute(ConsoleKey key);
        IConsoleCommand PrevCommand();
    }
}
