using System;
using MyApp;
using Objects.Models;
using Objects.Services;

namespace Canvas2._0.Helpers
{
	public class CourseHelper
    {
        private CourseService cs = new CourseService();
        private StudentHelper sh = new StudentHelper();

        public void AddOrUpdateCourse(Course? course = null)
		{
            Console.WriteLine("Course Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code: ");
            var c = Console.ReadLine() ?? string.Empty;

            bool isCreate = false;
            if (course == null)
            {
                isCreate = true;
                course = new Course();
            }

            course.Name = n;
            course.classCode = c;

            if (isCreate)
                cs.Add(course);
        }

        public void ListCourses()
        {
            cs.courseList.ForEach(Console.WriteLine);
        }

        public void AddStudentToRoster()
        {
            Console.WriteLine("Enter the name of the student you want to add: ");
            var n = Console.ReadLine() ?? string.Empty;
            var curStudent = sh.GetStudnet(n);
            if (curStudent == null)
                Console.Write($"No student with the name: {n}");
            else
            {

                Console.WriteLine("Enter the course code: ");
                var c = Console.ReadLine() ?? string.Empty;
                var curCourse = cs.courseList.FirstOrDefault(s => s.Name.ToUpper().Contains(c.ToUpper()));
                if (curCourse != null)
                {
                    curCourse.roster.Add(curStudent);
                    curStudent.courses.Add(curCourse);
                }
                else
                    Console.WriteLine($"Not a course with the code: {c}");
            }
        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the student: ");
            var n = Console.ReadLine() ?? string.Empty;

            var curCourse = cs.courseList.FirstOrDefault(s => s.Name.ToUpper().Contains(n.ToUpper()));

            if (curCourse == null)
            {
                    AddOrUpdateCourse(curCourse);
            }
            


        }
    }
}

