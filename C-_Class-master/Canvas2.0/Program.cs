using System;
using System.Collections.Specialized;
using Canvas2._0.Helpers;
using Objects.Models;
using Objects.Services;

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

            //List<Course> courseList = new List<Course>();
            var StudHelp = new StudentHelper();
            var CourseHelp = new CourseHelper();

            while (cont)
            {
                Console.WriteLine("1. Maintain Students");
                Console.WriteLine("2. Maintain Courses");
                Console.WriteLine("3. Exit");                      //Sys

                string choice = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(choice, out int choiceInt))
                {
                    if (choiceInt == 1)
                        ShowStudentMenu(StudHelp);
                    else if (choiceInt == 2)
                        ShowCourseMenu(CourseHelp);
                    else if (choiceInt == 3)
                        cont = false;
                    

                }
            }
        }

        static void ShowStudentMenu(StudentHelper StudHelp)
        {
            Console.WriteLine("1. Create a Student");           //Student
            Console.WriteLine("2. Remove a student to a course");
            Console.WriteLine("3. Search for a student");       //Student
            Console.WriteLine("4. List  all Students");         //Student
            Console.WriteLine("5. Update a student Info");      //Student

            var input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choiceInt))
            {
                 //Create a Student
                if (choiceInt == 1)
                {
                    StudHelp.AddOrUpdateStudent();
                }

                //Search for a student
                else if (choiceInt == 3)
                {
                    StudHelp.SearchStudents();
                }

                //List all students
                else if (choiceInt == 4)
                {
                    StudHelp.ListStudents();
                }

                //Update a students information
                else if (choiceInt == 9)
                {
                    StudHelp.AddOrUpdateStudent();
                }
            }
        }

        static void ShowCourseMenu(CourseHelper CourseHelp)
        {
            Console.WriteLine("1. Create a Course");            //Course
            Console.WriteLine("4. Search for a course");        //Course
            Console.WriteLine("5. List all courses");           //Course
            Console.WriteLine("8. Update Course Info");         //Course

            var input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choiceInt))
            {
                //Create a course
                if (choiceInt == 1)
                {
                    CourseHelp.AddOrUpdateCourse();
                }

                //Remove a student from a course
                else if (choiceInt == 2)
                {
                    CourseHelp.RemoveStudentFromCourse();
                }


                //Search for a course
                else if (choiceInt == 3)
                {
                    Console.WriteLine("Enter the class code: ");
                    var n = Console.ReadLine() ?? string.Empty;
                    CourseHelp.SearchCourse(n);
                }

                //List all courses
                else if (choiceInt == 4)
                {
                    CourseHelp.SearchCourse();
                }

                //Updtae course information
                else if (choiceInt == 5)
                {
                    CourseHelp.AddOrUpdateCourse();
                }

            }
        }
    }

 
}

