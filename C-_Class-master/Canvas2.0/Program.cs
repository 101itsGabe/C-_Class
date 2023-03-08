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

            for(int i = 0; i < 5; i++) 
            {
                var newStudent = new Student();
                //newStudent.Id = i + 1;
                newStudent.Name = $"S{i + 1}";
                newStudent.Classification = PersonClassification.Freshman;
                StudHelp.addStudent(newStudent);
            }
            var gabe = new Student();
            //gabe.Id = 6;
            gabe.Name = "Gabe";
            gabe.Classification= PersonClassification.Senior;
            StudHelp.addStudent(gabe);

            
            
            while (cont)
            {
                Console.WriteLine("1. Maintain People");
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
            Console.WriteLine("1. Create a Person");           //Student
            Console.WriteLine("2. Remove a student to a course");
            Console.WriteLine("3. Search for a student");       //Student
            Console.WriteLine("4. List  all Students");         //Student
            Console.WriteLine("5. Update a student Info");      //Student
            Console.WriteLine("6. Show a student grade");
            Console.WriteLine("7. Show all course grades");
            Console.WriteLine("8. Show GPA");

            var input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choiceInt))
            {
                 //Create a Student
                if (choiceInt == 1)
                {
                    StudHelp.AddOrUpdatePerson();
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
                else if (choiceInt == 5)
                {
                    StudHelp.AddOrUpdatePerson();
                }

                else if(choiceInt == 6)
                {
                    StudHelp.ShowGrades();
                }

                else if (choiceInt == 7) 
                {
                    StudHelp.ShowAllCourseGrades();
                }

                else if(choiceInt == 8) 
                {
                    StudHelp.ShowGPA();
                }
            }
        }

        static void ShowCourseMenu(CourseHelper CourseHelp)
        {
            Console.WriteLine("1. Create a Course");            //Course
            Console.WriteLine("2. Search for a course");        //Course
            Console.WriteLine("3. List all courses");           //Course
            Console.WriteLine("4. Update Course Info");         //Course\
            Console.WriteLine("5. Give a grade");
            Console.WriteLine("6. Add a Student");
            Console.WriteLine("7. Remove a Student");
            Console.WriteLine("8. Create an Announcment");
            Console.WriteLine("9. Update an Announcment");
            Console.WriteLine("10. Delete an Announcment");
            Console.WriteLine("11. Show an Announcment");
            Console.WriteLine("12. Add a new Module ");
            Console.WriteLine("13. Update a Module");
            Console.WriteLine("14. Delete a Module");
            Console.WriteLine("15. Show a Module");




            var input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choiceInt))
            {
                //Create a course
                if (choiceInt == 1)
                {
                    CourseHelp.AddOrUpdateCourse();
                }


                //Search for a course
                else if (choiceInt == 2)
                {
                    
                    CourseHelp.SearchCourse();
                }

                //List all courses
                else if (choiceInt == 3)
                {
                    CourseHelp.ListAllCourses();
                }

                //Updtae course information
                else if (choiceInt == 4)
                {
                    CourseHelp.AddOrUpdateCourse();
                }

                else if (choiceInt == 5)
                {
                    CourseHelp.GiveGrade();
                }

                else if(choiceInt == 6)
                {
                    CourseHelp.AddStudentToCourse();
                }

                else if(choiceInt == 7)
                {
                    CourseHelp.RemoveStudentFromCourse();
                }
                else if(choiceInt== 8) 
                {
                    CourseHelp.CreateAnnouncement();
                }
                else if (choiceInt == 9)
                {
                    CourseHelp.UpdateAnnouncement();
                }
                else if (choiceInt == 10)
                {
                    CourseHelp.DeleteAnnouncement();
                }
                else if (choiceInt == 11)
                {
                    CourseHelp.ShowAnnouncement();
                }

                else if(choiceInt == 12)
                {
                    CourseHelp.AddNewModule();
                }
                
                else if (choiceInt == 13)
                {
                    CourseHelp.UpdateModule();
                }
                else if (choiceInt == 14)
                {
                    CourseHelp.DeleteModule();
                }
                else if (choiceInt == 15)
                {
                    CourseHelp.ShowModule();
                }

            }
        }
    }

 
}

