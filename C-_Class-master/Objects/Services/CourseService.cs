using System;
using Objects.Models;

//This is for access to the list that CourseHelper will use
namespace Objects.Services
{
	public class CourseService
	{
		public List<Course> courseList;//doesnt have getter or setter
        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        private CourseService()
        {
            courseList= new List<Course>();
        }
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

