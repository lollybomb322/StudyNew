using EmployeesConsoleCommand;
using EmployeesConsoleCommand.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesConsoleCommand
{
    static class Print
    {
        public static void PrintPointsMenu(IEnumerable<string>? pointsMenu)
        {
            if (pointsMenu == null)
                return;
            int i = 1;
            foreach (string point in pointsMenu)
            {
                Console.WriteLine("[" + i + "] " + point);
                i++;
            }
        }
        public static string? InputString(string mes)
        {
            Console.WriteLine(mes);
            Console.CursorVisible = true;
            StringBuilder buffer = new();
            ConsoleKeyInfo ski = Console.ReadKey(true);
            while (ski.Key != ConsoleKey.Escape && ski.Key != ConsoleKey.Enter)
            {
                if (ski.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");
                    if (buffer.Length > 0)
                        buffer.Length--;
                }
                else
                {
                    Console.Write(ski.KeyChar);
                    buffer.Append(ski.KeyChar);
                }
                ski = Console.ReadKey(true);
            }
            Console.CursorVisible = false;
            if (ski.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return buffer.ToString();
            }
            return null;
        }
        
        public static void PrintLogo(LogoEnum logo)
        {
            Console.Clear();
            switch (logo)
            {
                case LogoEnum.Welcome:
                    Console.WriteLine(
@"
 _    _        _                                _ 
| |  | |      | |                              | |
| |  | |  ___ | |  ___   ___   _ __ ___    ___ | |
| |/\| | / _ \| | / __| / _ \ | '_ ` _ \  / _ \| |
\  /\  /|  __/| || (__ | (_) || | | | | ||  __/|_|
 \/  \/  \___||_| \___| \___/ |_| |_| |_| \___|(_)
");
                    break;

                case LogoEnum.ViewEmployees:
                    Console.WriteLine(
@"
 _____                    _                                
|  ___|                  | |                               
| |__   _ __ ___   _ __  | |  ___   _   _   ___   ___  ___ 
|  __| | '_ ` _ \ | '_ \ | | / _ \ | | | | / _ \ / _ \/ __|
| |___ | | | | | || |_) || || (_) || |_| ||  __/|  __/\__ \
\____/ |_| |_| |_|| .__/ |_| \___/  \__, | \___| \___||___/
                  | |                __/ |                 
                  |_|               |___/ 
");
                    break;
                case LogoEnum.AddEmployee:
                    Console.WriteLine(
@"
  ___       _      _   _____                    _                           
 / _ \     | |    | | |  ___|                  | |                          
/ /_\ \  __| |  __| | | |__   _ __ ___   _ __  | |  ___   _   _   ___   ___ 
|  _  | / _` | / _` | |  __| | '_ ` _ \ | '_ \ | | / _ \ | | | | / _ \ / _ \
| | | || (_| || (_| | | |___ | | | | | || |_) || || (_) || |_| ||  __/|  __/
\_| |_/ \__,_| \__,_| \____/ |_| |_| |_|| .__/ |_| \___/  \__, | \___| \___|
                                        | |                __/ |            
                                        |_|               |___/                               
");
                    break;
                case LogoEnum.EmployeeProfile:
                    Console.WriteLine(
@"
 _____                    _                            ______                __  _  _       
|  ___|                  | |                           | ___ \              / _|(_)| |      
| |__   _ __ ___   _ __  | |  ___   _   _   ___   ___  | |_/ / _ __   ___  | |_  _ | |  ___ 
|  __| | '_ ` _ \ | '_ \ | | / _ \ | | | | / _ \ / _ \ |  __/ | '__| / _ \ |  _|| || | / _ \
| |___ | | | | | || |_) || || (_) || |_| ||  __/|  __/ | |    | |   | (_) || |  | || ||  __/
\____/ |_| |_| |_|| .__/ |_| \___/  \__, | \___| \___| \_|    |_|    \___/ |_|  |_||_| \___|
                  | |                __/ |                                                  
                  |_|               |___/                                                   
");
                    break;
                case LogoEnum.DeleteEmployee:
                    Console.WriteLine(
@"
______        _        _           _____                    _                           
|  _  \      | |      | |         |  ___|                  | |                          
| | | |  ___ | |  ___ | |_   ___  | |__   _ __ ___   _ __  | |  ___   _   _   ___   ___ 
| | | | / _ \| | / _ \| __| / _ \ |  __| | '_ ` _ \ | '_ \ | | / _ \ | | | | / _ \ / _ \
| |/ / |  __/| ||  __/| |_ |  __/ | |___ | | | | | || |_) || || (_) || |_| ||  __/|  __/
|___/   \___||_| \___| \__| \___| \____/ |_| |_| |_|| .__/ |_| \___/  \__, | \___| \___|
                                                    | |                __/ |            
                                                    |_|               |___/             
");
                    break;
                case LogoEnum.EditEmployee:
                    Console.WriteLine(
@"
 _____      _  _  _     _____                    _                           
|  ___|    | |(_)| |   |  ___|                  | |                          
| |__    __| | _ | |_  | |__   _ __ ___   _ __  | |  ___   _   _   ___   ___ 
|  __|  / _` || || __| |  __| | '_ ` _ \ | '_ \ | | / _ \ | | | | / _ \ / _ \
| |___ | (_| || || |_  | |___ | | | | | || |_) || || (_) || |_| ||  __/|  __/
\____/  \__,_||_| \__| \____/ |_| |_| |_|| .__/ |_| \___/  \__, | \___| \___|
                                         | |                __/ |            
                                         |_|               |___/           
");
                    break;
}
        }
    }
}
