using System;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using MyApp;
using Objects.Models;
using Objects.Services;

namespace Canvas2._0.Helpers
{
	public class CourseHelper
    {
        private CourseService cs = new CourseService();
        private StudentService sh;
        public CourseHelper(StudentService s)
        {
            sh = s;
        }

        public void AddOrUpdateCourse(Course? course = null)
		{
            Console.WriteLine("Course Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code: ");
            var c = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which Students should be enrolled in this course? 'Q' to quit: ");
            var roster = new List<Person>();
            bool continueAdding = true;
            
            

            while (continueAdding)
            {
                sh.Students.Where(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())).ToList().ForEach(Console.WriteLine);

                var studName = "Q";
                if(sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                {
                    studName = Console.ReadLine() ?? string.Empty;
                }

                if (studName.Equals("Q") || !sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                {
                    continueAdding = false;
                }
                else
                {
                    var curStudent = sh.Students.FirstOrDefault(s => s.Name.ToUpper().Contains(studName.ToUpper()));
                    if(curStudent != null && !roster.Contains(curStudent)) 
                    {
                        roster.Add(curStudent);
                    }
                }
            }

                bool isCreate = false;
                if (course == null)
                {
                    isCreate = true;
                    course = new Course();
                }

            course.Name = n;
            course.classCode = c;
            course.Roster = new List<Person>();
            course.Roster.AddRange( roster );



                if (isCreate)
                    cs.Add(course);
            
        }

        public void ListCourses()
        {
            cs.courseList.ForEach(Console.WriteLine);
        }

        public void AddStudentToRoster()
        {
            
        }

        public void SearchCourse()
        {
            Console.WriteLine("Enter the class code: ");
            var n = Console.ReadLine() ?? string.Empty;

            cs.Search(n).ToList().ForEach(Console.WriteLine);   //Your not trying to assign anything so it is ok for now
        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the course code: ");
            var n = Console.ReadLine() ?? string.Empty;

            var curCourse = cs.courseList.FirstOrDefault(s => s.classCode.ToUpper().Contains(n.ToUpper()));

            if (curCourse == null)
            {
                    AddOrUpdateCourse(curCourse);
            }
            

        }

        public void RemoveStudentFromCourse()
        {
            Console.WriteLine("Enter class code: ");
            var c = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.courseList.FirstOrDefault(s => s.classCode.Contains(c));
            if (curCourse == null)
                Console.WriteLine($"{c} not found");
            else
            {
                bool isRemoving = true;
                while(isRemoving)
                { 
                    curCourse.Roster.ToList().ForEach(Console.WriteLine);
                    Console.WriteLine("Enter the student name you would like to remove 'Q' to quit: ");
                    var n = Console.ReadLine() ?? string.Empty;

                    if(n == "Q")
                    {
                        isRemoving = false;
                    }

                    else
                    {
                        var curStudent = sh.Students.FirstOrDefault(s => s.Name.ToUpper().Contains(n.ToUpper()));
                        if (curStudent == null) { Console.WriteLine("Student not found"); }
                        else
                        {
                            curCourse.Roster.Remove(curStudent);
                        }
                    }
                }
            }

        }
    }
}

