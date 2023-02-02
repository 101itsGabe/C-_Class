using System;
using System.Collections.Specialized;

using Objects.Models;

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

            List<Course> courseList = new List<Course>();
            List<Person> personList = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                Person n = new Person();
                n.Name = "Student"; 
                n.Name += i.ToString();
                n.classification = "Freshman";
                personList.Add(n);
            }

            for (int i = 0; i < 5; i++)
            {
                Course close = new Course();
                close.Name = "Class";
                close.Name += i.ToString();
                close.classCode = "CLA";
                for(int j = 0;j < 4; j++)
                    close.classCode += i.ToString();
                close.Description = "A nice class";
                courseList.Add(close);
            }

            while (cont)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Create a Course");
                Console.WriteLine("2. Create a Student");
                Console.WriteLine("3. Add a student to a course");
                Console.WriteLine("4. Remove a student to a course");
                Console.WriteLine("5. Search for a course");
                Console.WriteLine("6. List all courses");
                Console.WriteLine("7. Search for a student");
                Console.WriteLine("8. List all students");
                Console.WriteLine("9. List all courses a student is taking");
                Console.WriteLine("10. Update a courses information");
                Console.WriteLine("11. Update a student information");
                Console.WriteLine("12. Create an assignment and add it to the list for a course");
                Console.WriteLine("13. Exit");

                string choice = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(choice, out int choiceInt))
                {
   

                    //Create a course
                    if (choiceInt == 1)
                    {
                        var newCourse = new Course();
                        Console.WriteLine("Course Name: ");
                        newCourse.Name = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Course Code: ");
                        var code = Console.ReadLine() ?? string.Empty;
                        newCourse.classCode = code;

                        Console.WriteLine("Course Description: ");
                        newCourse.Description = Console.ReadLine() ?? string.Empty;
                        courseList.Add(newCourse);
                    }

                    //Create a Student
                    else if (choiceInt == 2)
                    {
                        var newPerson = new Person();
                        Console.WriteLine("Person Name: ");
                        newPerson.Name = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Person Classification: ");
                        newPerson.classification = Console.ReadLine() ?? string.Empty;
                        personList.Add(newPerson);
                    }

                    //Add a student to a course
                    else if (choiceInt == 3)
                    {
                        Person curPerson = new Person();
                        Console.WriteLine("Which Student would you like to add?: ");
                        var studentString = Console.ReadLine() ?? string.Empty; ;
                        Console.WriteLine("Enter the class code: ");
                        var courseCode = Console.ReadLine() ?? string.Empty;

                        foreach (Person p in personList)
                        {
                            if (p.Name.Contains(studentString, StringComparison.InvariantCultureIgnoreCase))
                            {
                                curPerson = p;
                                break;
                            }
                        }
                        if (curPerson == null)
                            Console.WriteLine("Sorry we couldnt find " + studentString);


                        bool found = false;
                        foreach (Course c in courseList)
                        {
                            if (c.classCode == courseCode)
                            {
                                if (curPerson != null)
                                {
                                    Console.WriteLine("CurPerson Name:  " + curPerson.Name);
                                    c.roster.Add(curPerson);
                                    Console.WriteLine("Successfully added " + curPerson.Name + " to " + c.Name);
                                    curPerson.courses.Add(c);
                                    found = true;
                                    break;
                                }
                            }

                        }

                        if (!found)
                            Console.WriteLine("Could not find Course with code: " + courseCode);

                    }


                    //Remove a student from a course
                    else if (choiceInt == 4)
                    {
                        Course curCourse = new Course();
                        Console.WriteLine("\nWhich Student would you like to remove?: ");
                        var studentString = Console.ReadLine() ?? string.Empty; ;
                        Console.WriteLine("\nEnter the class code: ");
                        var courseCode = Console.ReadLine() ?? string.Empty;

                        foreach (Course c in courseList)
                        {
                            if (courseCode == c.classCode)
                            {
                                curCourse = c;
                                break;
                            }
                        }


                        foreach (Person p in curCourse.roster)
                        {
                            if (studentString == p.Name)
                            {
                                curCourse.roster.Remove(p);
                                p.courses.Remove(curCourse);
                                break;
                            }
                        }



                    }


                    //Search for a course
                    else if (choiceInt == 5)
                    {
                        Console.WriteLine("Enter a class code: ");
                        var curCode = Console.ReadLine() ?? string.Empty;

                        foreach (Course c in courseList)
                        {
                            if (curCode == c.classCode)
                            {
                                Console.WriteLine("\nClass: " + c.Name);
                                Console.WriteLine("Class Code: " + c.classCode);
                                Console.WriteLine("Description: " + c.Description);
                                Console.WriteLine("\nStudents in this class: ");
                                foreach (Person p in c.roster)
                                {
                                    Console.WriteLine(p.Name);
                                }

                                Console.WriteLine("\n");
                                Console.WriteLine("Assignments:");
                                foreach (Assignment a in c.assignments)
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine(a.Name);
                                    Console.WriteLine(a.Description);
                                    Console.WriteLine(a.totalPoints);
                                    Console.WriteLine(a.dueDate);
                                    Console.WriteLine("\n");
                                }
                                break;
                            }
                        }


                    }

                    //List all courses
                    else if (choiceInt == 6)
                    {
                        Console.WriteLine("All Courses: ");
                        if (courseList.Count() == 0)
                        {
                            Console.WriteLine("There are no courses yet.");
                        }
                        else
                        {
                            foreach (Course c in courseList)
                            {
                                Console.WriteLine("Couse: " + c.Name);
                                Console.WriteLine("Class Code: " + c.classCode);
                                Console.WriteLine("Description: " + c.Description);
                                Console.WriteLine("\n");
                            }
                            Console.WriteLine("\n");
                        }
                    }


                    //Search for a student
                    else if (choiceInt == 7)
                    {
                        Console.WriteLine("Enter a Students name: ");
                        var name = Console.ReadLine() ?? string.Empty;

                        foreach (Person p in personList)
                        {
                            if (name.Equals(p.Name))
                            {
                                Console.WriteLine("Student Name: " + p.Name);
                                Console.WriteLine("Classification: " + p.classification);
                                Console.WriteLine("\nClasses: ");

                                foreach (Course c in p.courses)
                                {
                                    Console.WriteLine("\nClass: " + c.Name);
                                    Console.WriteLine("Class Code: " + c.classCode);
                                    Console.WriteLine("Description: " + c.Description);
                                }
                                break;
                            }
                        }
                        Console.WriteLine("\n");
                    }

                    //List all students
                    else if (choiceInt == 8)
                    {
                        Console.WriteLine("All studemts: ");
                        if (personList.Count() == 0)
                        {
                            Console.WriteLine("There are no students yet.");
                        }
                        else
                        {
                            foreach (Person c in personList)
                            {
                                Console.WriteLine("Couse: " + c.Name);
                                Console.WriteLine("Class Code: " + c.classification + "\n");

                            }
                            Console.WriteLine("\n");
                        }
                    }


                    //List all courses a student is taking
                    else if (choiceInt == 9)
                    {
                        Console.WriteLine("Enter the students name: ");
                        var name = Console.ReadLine();
                        foreach (Person p in personList)
                        {
                            if (name == p.Name)
                            {
                                foreach (Course c in p.courses)
                                {
                                    Console.WriteLine(c.Display);
                                }
                                break;
                            }
                        }
                    }

                    //Updtae course information
                    else if (choiceInt == 10)
                    {
                        Console.WriteLine("Enter the course code you would like to update: ");
                        var code = Console.ReadLine();
                        Course curCourse = null;

                        foreach (Course c in courseList)
                        {
                            if (c.classCode == code)
                            {
                                curCourse = c;
                                break;
                            }
                        }

                        Console.WriteLine("What would you like to update?");
                        Console.WriteLine("Name - N");
                        Console.WriteLine("Description - D");
                        Console.WriteLine("Course Code - C");
                        var ch = Console.ReadLine();
                        bool valid = false;

                        if (curCourse != null)
                        {
                            while (!valid)
                            {
                                switch (ch)
                                {
                                    case "C":
                                        Console.WriteLine("Enter the new Code you want to give to the course: ");
                                        curCourse.classCode = Console.ReadLine() ?? string.Empty;
                                        valid = true;
                                        break;

                                    case "D":
                                        Console.WriteLine("Enter the new description you would like to give to the course: ");
                                        curCourse.Description = Console.ReadLine() ?? string.Empty;
                                        valid = true;
                                        break;

                                    case "N":
                                        Console.WriteLine("Enter the new name you would like to give the class: ");
                                        curCourse.Name = Console.ReadLine() ?? string.Empty;
                                        valid = true;
                                        break;



                                    default:
                                        valid = false;
                                        break;


                                }
                            }
                        }
                        else
                            Console.WriteLine("Sorry, there is no class with the code: " + code);
                    }

                    //Update a students information
                    else if (choiceInt == 11)
                    {
                        Console.WriteLine("Enter the name of the student you would like to update: ");
                        var name = Console.ReadLine();
                        Person curPerson = null;

                        foreach (Person p in personList)
                        {
                            if (p.Name == name)
                            {
                                curPerson = p;
                                break;
                            }
                        }

                        if (curPerson == null)
                        {
                            Console.WriteLine("Sorry " + name + "not found");
                        }

                        else
                        {
                            Console.WriteLine("What would you like to update?");
                            Console.WriteLine("Name - N");
                            Console.WriteLine("Classification - C");
                            var ch = Console.ReadLine();
                            bool valid = false;

                            while (!valid)
                            {
                                switch (ch)
                                {
                                    case "C":
                                        Console.WriteLine("Enter the new Code you want to give to the course: ");
                                        curPerson.classification = Console.ReadLine() ?? string.Empty;
                                        valid = true;
                                        break;

                                    case "N":
                                        Console.WriteLine("Enter the new name you would like to give the person: ");
                                        curPerson.Name = Console.ReadLine() ?? string.Empty;
                                        valid = true;
                                        break;



                                    default:
                                        valid = false;
                                        break;


                                }
                            }
                        }
                       
                    }

                    //Create an assignment and add it to the courses assignment
                    else if (choiceInt == 12)
                    {
                        Console.WriteLine("Enter the class code you would like to add the assignment to: ");
                        var code = Console.ReadLine() ?? string.Empty;

                        Assignment newAssignment = new Assignment();
                        Console.WriteLine("Enter the name of the new assignment");
                        newAssignment.Name = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter the description of the new assignment");
                        newAssignment.Description = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter the total points the assignment will be worth: ");
                        var tp = Console.ReadLine() ?? string.Empty;
                        if (int.TryParse(tp, out var value))
                        {
                            newAssignment.totalPoints = value;
                        }

                        Console.WriteLine("Enter the due date of the assignment: ");
                        newAssignment.dueDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                        foreach (Course c in courseList)
                        {
                            c.assignments.Add(newAssignment);
                        }

                    }


                    else if (choiceInt == 13)
                    {
                        cont = false;
                    }

                }
            }
        }
    }
}

