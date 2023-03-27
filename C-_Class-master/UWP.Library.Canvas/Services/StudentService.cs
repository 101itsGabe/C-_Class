using System;
using System.Collections.Generic;
using System.Linq;
using Objects.Models;

namespace Objects.Services
{
	public class StudentService
	{
        public static CourseService _cs;
		public List<Person> personList;
		private static StudentService _instance;
        private List<Person> persons;

		public StudentService()
		{
			personList = new List<Person>();
            _cs = CourseService.Current;
            persons = new List<Person>();
            for(int i = 0; i < 30; i++) 
            {
                persons.Add(new Student { Name = $"S{i + 1}", Classification=PersonClassification.Freshman });
            }

            persons.Add(new Student { Name = "Gabe", Classification= PersonClassification.Senior });
            
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

		public void Add(Person s)
		{
			personList.Add(s);
		}

		public List<Person> People
		{
			get { return persons; }
		}

        public Person GetStudent(string n)
        {
            return (Person)People.FirstOrDefault(c => c.Name == n);
        }

        public void RemoveStudent(string id)
        {
            var c = GetStudent(id);
            if (c != null)
                People.Remove(c);
            else
                Console.WriteLine("Student not Found");
        }

        public IEnumerable<Person> Seacrh(string n)
		{
			return personList.Where(s => s.Name.ToUpper().Contains(n.ToUpper()));
		}


      

       

        public IEnumerable<Assignment> GetAssignment(string sn, string ID)
        {

            Student curStudent = (Student)GetStudent(sn);
            curStudent.Grades.TryGetValue(ID, out List<Assignment> assign);

            return assign.Select(a => a);
        }

        public void AddCourseGrade(string sn, string cCode, decimal grade)
        {
            Student curStudent = (Student)GetStudent(sn);
            if(curStudent != null) 
                curStudent.CourseGrade.Add(cCode, grade);
        }

        public void UpdateCourseGrade(string sn, string cCode, decimal grade)
        {
            Student curStudent = (Student)GetStudent(sn);
            if (curStudent != null)
            {
                if (curStudent.CourseGrade.ContainsKey(cCode))
                    curStudent.CourseGrade[cCode] = grade;
            }
        }

        public decimal CalculateGrade(string sn, string cc)
        {
            var curStudent = (Student)GetStudent(sn);
            var curCourse = _cs.GetCourse(cc);
            List<decimal> tempGrade = new List<decimal>();
            decimal grade = 0;
            decimal classGrade = 0;
            if (!curStudent.Grades.TryGetValue(cc, out List<Assignment> curList))
                    Console.WriteLine("Not Working");

            foreach(var g in curCourse.AssignmentGroups)
            {
                grade = 0;
                foreach(var a in g.Assignments) 
                {
                    var curAssign = curList.FirstOrDefault(assignment=> assignment.Id == a.Id);
                    if(curAssign != null ) 
                     grade += curAssign.earnedPoints;
                }
                classGrade = (grade/g.totalPoints) * 100;
                tempGrade.Add(classGrade * (g.weight/100));
            }

            decimal finalGrade = 0;

            tempGrade.ForEach(g => finalGrade += g);

            return finalGrade;
        }


    }
}

