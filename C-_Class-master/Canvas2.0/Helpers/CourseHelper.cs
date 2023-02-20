using System;
using Objects.Models;
using Objects.Services;

namespace Canvas2._0.Helpers
{
	public class CourseHelper
	{
		private CourseService cs = new CourseService();
		public void CreateCourseRecord()
		{
            var newCourse = new Course();
            Console.WriteLine("Course Name: ");
            newCourse.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Course Code: ");
            newCourse.classCode = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Course Description: ");
            newCourse.Description = Console.ReadLine() ?? string.Empty;
            cs.Add(newCourse);
        }

        public void ListCourses()
        {
            cs.courseList.ForEach(Console.WriteLine);
        }
	}
}

