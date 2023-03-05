using System;
using System.Linq;
using Objects.Models;

//This is for access to the list that CourseHelper will use
namespace Objects.Services
{
	public class CourseService
	{
		public List<Course> courseList;//doesnt have getter or setter
        private static CourseService? _instance;
        //private static StudentService? _studentService;

        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return courseList.SelectMany(c => c.Assignments);
            }
        }

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
            //_studentService = StudentService.Current;
        }
        public void Add(Course c)
        {
            courseList.Add(c);
        }

        public IEnumerable<Course> Search(string n)
        {
            return courseList.Where(s => s.classCode.ToUpper().Contains(n.ToUpper()));
        }

        public Course? GetCourse(string id)
        {
            return courseList.FirstOrDefault(c => c.classCode == id);
        }

        public Assignment? GetAssignment(Course c, int aId)
        {
            return c.Assignments.FirstOrDefault(a => a.Id == aId);
        }

        public void giveGrade(string courseId, string studentName, int aId, decimal grade)
        {
            var curCourse = GetCourse(courseId);
            var s = curCourse.Roster.FirstOrDefault(s => s.Name.ToUpper() == studentName.ToUpper());
            s.Grades.TryGetValue(courseId, out List<Assignment>? assign);
            var curAssign = assign.FirstOrDefault(a => a.Id == aId);
            curAssign.earnedPoints = grade;
            
        }

        public AssignmentGroup GetAssignmentGroup(string classCode, string groupName)
        {
            var curCourse = GetCourse(classCode);
            var curGroup = curCourse.AssignmentGroups.FirstOrDefault(g => g.Name.ToUpper() == groupName.ToUpper());
            return curGroup;
        }

        
    }
}

