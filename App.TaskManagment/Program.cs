using System;
using System.Collections.Specialized;
using App.TaskManagment.Helpers;
//Fully Qualified Name (FQN)
using Library.TaskManagement.Models;
using Library.TaskManagement.Services;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            var todoHelper = new ItemHelper();

            while (cont)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add a Task");
                Console.WriteLine("2. Delete a Task");
                Console.WriteLine("3. Update a Task");
                Console.WriteLine("4. List all Tasks");
                Console.WriteLine("5. Seacrh for Tasks");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(choice, out int choiceInt))
                {
                    //Add a task
                    if (choiceInt == 1)
                    {

                        new ItemHelper(toDoService).Add();

                    }

                    //List all tasks
                    else if (choiceInt == 5)
                    {
                        todoservice.Tasks.ForEach(number => Console.WriteLine(number));
                    }

                    //Search for tasks
                    else if (choiceInt == 6)
                    {
                        Console.WriteLine("Enter the seacrh term: ");
                        var query = Console.ReadLine();

                        var FilteredTasks = todoservice
                            .Where(t =>
                            ((t is Appointment) || ((t is ToDo) && (t as ToDo).IsComplete)) &&
                            t.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                            || t.Description.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                            );

                    }
                                
                    else if (choiceInt == 4)
                            {
                                cont = false;
                            }
                                           
                }
            }
        }
    }
}