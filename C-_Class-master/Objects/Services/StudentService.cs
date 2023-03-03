using System;
using Objects.Models;

namespace Objects.Services
{
	public class StudentService
	{
        public static CourseService? _cs;
		public List<Student> studentList;
		private static StudentService? _instance;

		private StudentService()
		{
			studentList = new List<Student>();
            _cs = CourseService.Current;
		}

		public static StudentService Current
		{
			get 
			{
				if(_instance == null)
				{
					_instance = new StudentService();
				}
				return _instance;
			}
		}

		public void Add(Student s)
		{
			studentList.Add(s);
		}

		public List<Student> Students
		{
			get { return studentList; }
		}

        public Student? GetStudent(string n)
        {
            return Students.FirstOrDefault(c => c.Name == n);
        }

        public void RemoveStudent(string id)
        {
            var c = GetStudent(id);
            if (c != null)
                Students.Remove(c);
            else
                Console.WriteLine("Student not Found");
        }

        public IEnumerable<Student> Seacrh(string n)
		{
			return studentList.Where(s => s.Name.ToUpper().Contains(n.ToUpper()));
		}


        public IEnumerable<Submission> Submissions
        {
            get
            {
                return Students.SelectMany(s => s.Submissions).Take(100);
            }
        }

        public void AddSubmission(int id, string sname, string cc,int aId)
        {
            var curCourse = _cs.GetCourse(cc);
            var curStudent = GetStudent(sname);
            var curAssign = _cs.GetAssignment(curCourse, aId);
            Submission s = new Submission(id,curAssign,curCourse);
            if (curStudent != null)
            {
                curStudent.Submissions.Add(s);
            }
        }

        public IEnumerable<decimal> GetGrades(string sn, string ID)
        {

            Student curStudent = GetStudent(sn);
            if (curStudent != null)
            {

                if (!curStudent.Grades.TryGetValue(ID, out List<Assignment>? assign))
                    return null;
            }

            return assign.Select(a => a.earnedPoints);
        }



    }
}

