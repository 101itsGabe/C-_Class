using System;
//Fully Qualified Name (FQN)
using Library.TaskManagement.Models;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            //Having this list to null is VERY BAD
            //Beacuse you dont control it you cant verify if its null
            //IF it is null everything will EXPLODE!!!

            List<Item> taskList = new List<Item>();

            while (cont)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add a Task");
                Console.WriteLine("2. List all Tasks");
                Console.WriteLine("3. Seacrh for Tasks");
                Console.WriteLine("4. Create a Course");
                Console.WriteLine("5. Create a Student");
                Console.WriteLine("6. Add a student to a course");
                Console.WriteLine("7. Remove a student to a course");
                Console.WriteLine("8. Search for a course");
                Console.WriteLine("9. List all courses");
                Console.WriteLine("10. Search for a student");
                Console.WriteLine("11. List all students");
                Console.WriteLine("12. List all courses a student is taking");
                Console.WriteLine("13. Update a courses information");
                Console.WriteLine("14. Update a student information");
                Console.WriteLine("15. Create an assignment and add it to the list for a course");

                Console.WriteLine("16. Exit");

                string choice = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(choice, out int choiceInt))
                {
                    //Add a task
                    if (choiceInt == 1)
                    {
                        var isToDo = true;
                        Console.WriteLine("Is this a Calander Appointment?(T/C)");
                        var response = Console.ReadLine() ?? string.Empty;
                        //If there is a Y character that has an accent mark it will still be Y
                        //and ignores capitals
                        if(response.Equals("Y",StringComparison.InvariantCultureIgnoreCase))
                        {
                            isToDo = false;
                        }

                        var newTask = new Item();

                        if (isToDo)
                        {
                            var newToDo = newTask as ToDo;
                            newToDo.IsComplete = false;
                            taskList.Add(newToDo);
                        }
                        else
                        {
                            var newAppointment = newTask as Appointment;
                            newAppointment.Start = DateTime.Now;
                            newAppointment.End = DateTime.Now.AddHours(1);
                            taskList.Add(newAppointment);
                        }   
                        Console.WriteLine("Enter a name: ");
                        newTask.Name = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter a Description: ");
                        newTask.Description = Console.ReadLine() ?? string.Empty;
                        taskList.Add(newTask);

                    }

                    //List all tasks
                    else if (choiceInt == 2)
                    {
                        taskList.ForEach(number => Console.WriteLine(number));
                    }

                    //Search for tasks
                    else if (choiceInt == 3)
                    {                        
                        Console.WriteLine("Enter the seacrh term: ");
                        var query = Console.ReadLine();

                        var FilteredTasks = taskList
                            .Where(t => 
                            ((t is Appointment) || ((t is ToDo) && (t as ToDo).IsComplete)) &&
                            t.Name.Contains(query,StringComparison.InvariantCultureIgnoreCase)
                            || t.Description.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                            );

                    }

                    //Create a course
                    else if (choiceInt == 4)

                    //Create a Student
                    else if (choiceInt == 5)

                    //Add a student to a course
                    else if (choiceInt == 6)

                    //Remove a student from a course
                    else if (choiceInt == 7)

                    //Search for a course
                    else if (choiceInt == 8)

                    //List all courses
                    else if (choiceInt == 9)

                    //Search for a student
                    else if (choiceInt == 10)

                    //List all students
                    else if (choiceInt == 11)

                    //List all courses a student is taking
                    else if (choiceInt == 12)

                    //Updtae course information
                    else if (choiceInt == 13)

                    //Update a students information
                    else if (choiceInt == 14)

                    //Create an assignment and add it to the courses assignment
                    else if (choiceInt == 15)

                    else if (choiceInt == 16)
                    {
                        cont = false;
                    }
                }
            }
        }
    }
}