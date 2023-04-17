using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Objects.Models;

//This is for access to the list that CourseHelper will use
namespace Objects.Services
{
	public class CourseService
	{
		public List<Course> courseList;//doesnt have getter or setter
        
        private static CourseService _instance;
        private List<Course> courses;

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

        public CourseService()
        {

            var ag = new AssignmentGroup { Name = "HW", weight = 25};
            var ag2 = new AssignmentGroup { Name = "Exam", weight = 75};
            var assignment = new Assignment { Name = "HW1", totalPoints = 100, AssignedGroup = ag.Name };
            var assignment2 = new Assignment { Name = "HW2", totalPoints = 100, AssignedGroup = ag.Name };
            var exam = new Assignment { Name = "Exam 1", totalPoints = 100, AssignedGroup = ag2.Name };
            ag.AddAssignment(assignment);
            courseList = new List<Course>();
            courses = new List<Course>
            {
               new Course {Name = "Data Structres", classCode = "COP3330", Description = "C++", roomLocation=1, Semester = CourseSemester.Fall, courseYear=2018 },
               new Course {Name = "Chem 101", classCode = "CHM2000", Description = "Swiffer", roomLocation=2, Semester = CourseSemester.Spring, courseYear=2018},
               new Course {Name = "Cooking w/ Advance Methods", classCode = "FOD2004", Description = "WEE", roomLocation=3, Semester = CourseSemester.Summer, courseYear=2018},
               new Course {Name = "C# Full Stack", classCode = "COP4349", Description = "WEE", roomLocation=4, Semester = CourseSemester.Spring, courseYear=2023},
               new Course {Name = "Biology", classCode = "BIO2001", Description = "WOO", roomLocation=1, Semester = CourseSemester.Fall, courseYear=2023},
               new Course {Name = "PE", classCode = "FED1001", Description = "EXCERSIE", roomLocation=2, Semester = CourseSemester.Fall, courseYear=2023}
            };
            foreach (var c in courses)
            {
                c.AssignmentGroups.Add(ag);
                c.AssignmentGroups.Add(ag2);
                c.Assignments.Add(assignment);
                c.Assignments.Add(assignment2);
                c.Assignments.Add(exam);
            }
        }

        public List<Course> Courses
        {
            get { return courses; }
        }

        public void Add(Course c)
        {
            courseList.Add(c);
        }

        

        public Course GetCourse(string id)
        {
            return courseList.FirstOrDefault(c => c.classCode.ToUpper() == id.ToUpper());
        }

        public Assignment GetAssignment(Course c, int aId)
        {
            return c.Assignments.FirstOrDefault(a => a.Id == aId);
        }

        

        /*
        public void giveGrade(string courseId, string studentName, int aId, decimal grade)
        {
            var curCourse = GetCourse(courseId);
            if (curCourse != null)
            {
                var curStudent = (Student)curCourse.Roster.FirstOrDefault(s => s.Name == studentName);

                if (curStudent != null)
                {
                    curStudent.Grades.TryGetValue(courseId, out var ListAssign);
                    Console.WriteLine($"Current ID: {aId}");
                    if (ListAssign != null)
                    {
                        ListAssign.ForEach(a => Console.WriteLine($"{a.Name} - {a.Id}"));
                        var curAssign = ListAssign.FirstOrDefault(a => a.Id == aId);
                        if (curAssign != null)
                            curAssign.earnedPoints = grade;
                    }
                }
            }
            
        }
        */



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
            if (curAnnon != null)
                curCourse.Announcements.Remove(curAnnon);
        }

        public void CreateAndUpdateModule(string cCode, string n)
        {
            var curCourse = GetCourse(cCode);
            Module curMod;
            if (!curCourse.Modules.Any() || curCourse.Modules.FindIndex(a => a.Name == n) == -1)
                curMod = new Module();
            else
                curMod = curCourse.Modules.FirstOrDefault(a => a.Name == n);
            if (curMod != null)
            {
                curMod.Name = n;
                curCourse.Modules.Add(curMod);
            }

        }

        public void DeleteModule(string cCode, string n)
        {
            var curCourse = GetCourse(cCode);
            var curMod = curCourse.Modules.FirstOrDefault(a => a.Name == n);
            if (curMod != null)
                curCourse.Modules.Remove(curMod);
        }





    }
}

