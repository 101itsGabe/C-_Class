using Library.TaskManagement.Models;
using Library.TaskManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.TaskManagment.Helpers
{
    public class ItemHelper
    {
        private ToDoService toDoService;

        public ItemHelper()
        {
            toDoService= new ToDoService();
        }

        public void Add(ToDoService toDoService)
        {
            var isToDo = true;
            Console.WriteLine("Is this a Calander Appointment?(T/C)");
            var response = Console.ReadLine() ?? string.Empty;
            //If there is a Y character that has an accent mark it will still be Y
            //and ignores capitals
            if (response.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                isToDo = false;
            }

            var newTask = new Item();

            Console.WriteLine("Enter a name:");
            newTask.Name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter a description:");
            newTask.Description = Console.ReadLine() ?? string.Empty;

            if (isToDo)
            {
                var newToDo = newTask as ToDo;
                newToDo.IsComplete = false;
                toDoService.AddToDo(newToDo);
            }

            else
            {
                var newAppointment = newTask as Appointment;
                newAppointment.Start = DateTime.Now;
                newAppointment.End = DateTime.Now.AddHours(1);
                toDoService.Tasks.Add(newAppointment);
            }

            toDoService.Tasks.Add(newTask);

        }

    }
}
