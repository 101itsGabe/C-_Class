using System;
using Objects.Models;

//This is for access to the list that CourseHelper will use
namespace Objects.Services
{
	public class CourseService
	{
		public List<Course> courseList = new List<Course>();//doesnt have getter or setter

        public void Add(Course c)
        {
            courseList.Add(c);
        }

        public IEnumerable<Course> Search(string n)
        {
            return courseList.Where(s => s.classCode.ToUpper().Contains(n.ToUpper()));
        }


    }
}

