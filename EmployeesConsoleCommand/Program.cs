using System.Text.Json;
using EmployeesConsoleCommand.ConsoleCommands;
using EmployeesConsoleCommand.DataController;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesConsoleCommand
{
    class Program
    {
        static void Main()
        {
            #region генерация базы из 20 сотрудников
            //var _employees = new List<Employee>
            //{
            //    new Employee(Guid.NewGuid(), "Oliver", "Smith", "+1 123-456-7890", "Hardworking, detail-oriented, team player"),
            //    new Employee(Guid.NewGuid(), "Sophia", "Johnson", "+1 234-567-8901", "Creative, efficient, problem solver"),
            //    new Employee(Guid.NewGuid(), "William", "Brown", "+1 345-678-9012", "Adaptable, curious, results-driven"),
            //    new Employee(Guid.NewGuid(), "Isabella", "Garcia", "+1 456-789-0123", "Collaborative, proactive, goal-oriented"),
            //    new Employee(Guid.NewGuid(), "James", "Miller", "+1 567-890-1234", "Analytical, organized, strategic thinker"),
            //    new Employee(Guid.NewGuid(), "Emma", "Davis", "+1 678-901-2345", "Innovative, flexible, excellent communicator"),
            //    new Employee(Guid.NewGuid(), "Benjamin", "Rodriguez", "+1 789-012-3456", "Persistent, resourceful, customer-focused"),
            //    new Employee(Guid.NewGuid(), "Ava", "Martinez", "+1 890-123-4567", "Passionate, empathetic, positive attitude"),
            //    new Employee(Guid.NewGuid(), "Ethan", "Hernandez", "+1 901-234-5678", "Energetic, motivated, detail-oriented"),
            //    new Employee(Guid.NewGuid(), "Mia", "Lopez", "+1 012-345-6789", "Resilient, adaptable, solution-focused"),
            //    new Employee(Guid.NewGuid(), "Michael", "Clark", "+1 234-567-8901", "Reliable, responsible, strong work ethic"),
            //    new Employee(Guid.NewGuid(), "Abigail", "King", "+1 345-678-9012", "Focused, organized, efficient"),
            //    new Employee(Guid.NewGuid(), "Alexander", "Wright", "+1 456-789-0123", "Flexible, creative, critical thinker"),
            //    new Employee(Guid.NewGuid(), "Emily", "Scott", "+1 567-890-1234", "Collaborative, detail-oriented, proactive"),
            //    new Employee(Guid.NewGuid(), "Daniel", "Green", "+1 678-901-2345", "Solution-focused, persistent, customer-oriented"),
            //    new Employee(Guid.NewGuid(), "Madison", "Baker", "+1 789-012-3456", "Excellent communicator, empathetic, positive attitude"),
            //    new Employee(Guid.NewGuid(), "Matthew", "Adams", "+1 890-123-4567", "Curious, results-driven, proactive"),
            //    new Employee(Guid.NewGuid(), "Chloe", "Nelson", "+1 901-234-5678", "Innovative, analytical, strategic thinker"),
            //    new Employee(Guid.NewGuid(), "David", "Carter", "+1 012-345-6789", "Flexible, adaptable, goal-oriented"),
            //    new Employee(Guid.NewGuid(), "Grace", "Mitchell", "+1 234-567-8901", "Collaborative, creative, efficient")
            //};
            //File.WriteAllText("./Data/EmployeesDataBase.json", JsonSerializer.Serialize(_employees));
            #endregion

            #region дублирование данных из Json в DB
            //var em = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText("./Data/EmployeesDataBase.json"));
            //SQLiteContext context = new SQLiteContext();
            //foreach (var t in em)
            //{
            //    context.Employees.Add(t);
            //}
            //context.SaveChanges();
            #endregion 

            IServiceCollection builderService = new ServiceCollection();
            builderService.AddSingleton<IDataController, DapperPostgresController>();
            IServiceProvider serviceProvider = builderService.BuildServiceProvider();

            
            IConsoleCommand currentStep = new MainMenuCommand(serviceProvider);
            Console.CursorVisible = false;
            while (true)
            {
                currentStep.Functionality();

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    currentStep = currentStep.PrevCommand();
                }
                else
                {
                    currentStep = currentStep.Execute(key);
                }
            }
        }
    }
}