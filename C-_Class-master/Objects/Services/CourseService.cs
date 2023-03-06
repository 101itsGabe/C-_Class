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
            return courseList.FirstOrDefault(c => c.classCode.ToUpper() == id.ToUpper());
        }

        public Assignment? GetAssignment(Course c, int aId)
        {
            return c.Assignments.FirstOrDefault(a => a.Id == aId);
        }

        public void giveGrade(string courseId, string studentName, int aId, decimal grade)
        {
            var curCourse = GetCourse(courseId);
            var curStudent = (Student)curCourse.Roster.FirstOrDefault(s => s.Name == studentName);
            
            if (curStudent != null)
            {
                curStudent.Grades.TryGetValue(courseId, out var ListAssign);
                Console.WriteLine($"Current ID: {aId}");
                ListAssign.ForEach(a => Console.WriteLine($"{a.Name} - {a.Id}"));
                var curAss = ListAssign.FirstOrDefault(a => a.Id == aId);
                curAss.earnedPoints = grade;
                Console.WriteLine(curAss.earnedPoints);
            }
            
        }

        public AssignmentGroup GetAssignmentGroup(string classCode, string groupName)
        {
            var curCourse = GetCourse(classCode);
            var curGroup = curCourse.AssignmentGroups.FirstOrDefault(g => g.Name.ToUpper() == groupName.ToUpper());
            return curGroup;
        }

        public void CreateAndUpdateAnnouncement(string cCode,string n, string d)
        {
            var curCourse = GetCourse(cCode);
            Announcement curAnn;
            if (!curCourse.Announcements.Any() || curCourse.Assignments.FindIndex(a => a.Name == n) == -1)
                curAnn = new Announcement();
            else
                curAnn = curCourse.Announcements.FirstOrDefault(a => a.Name == n);
            if (curAnn != null)
            {
                curAnn.Name = n;
                curAnn.Description = d;

                curCourse.Announcements.Add(curAnn);
            }

        }

        public void DeleteAnnouncement(string cCode, string n)
        {
            var curCourse = GetCourse(cCode);
            var curAnnon = curCourse.Announcements.FirstOrDefault(a => a.Name == n);
            if(curAnnon!= null)
                curCourse.Announcements.Remove(curAnnon);
        }



    }
}

