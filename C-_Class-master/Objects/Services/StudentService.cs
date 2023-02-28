using System;
using Objects.Models;

namespace Objects.Services
{
	public class StudentService
	{
		public List<Student> studentList;
		private static StudentService? _instance;

		private StudentService()
		{
			studentList = new List<Student>();
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

		public IEnumerable<Student> Search(string n)
		{
			return studentList.Where(s => s.Name.ToUpper().Contains(n.ToUpper()));
		}


		


    }
}

