using Library.TaskManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Services
{
    public class ToDoService
    {
        //Capital T is because its public
        public List<Item> Tasks { get; set; }
        public ToDoService() 
        {
            Tasks = new List<Item>();

        }

        public void AddToDo(ToDo t)
        {
            Tasks.Add(t);
        }
    }
}
