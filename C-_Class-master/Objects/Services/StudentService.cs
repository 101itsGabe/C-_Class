using System;
using Objects.Models;

namespace Objects.Services
{
	public class StudentService
	{
		public List<Person> studentList;
		private static StudentService? _instance;

		private StudentService()
		{
			studentList = new List<Person>();
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
			studentList.Add(s);
		}

		public List<Person> Students
		{
			get { return studentList; }
		}

		public IEnumerable<Person> Search(string n)
		{
			return studentList.Where(s => s.Name.ToUpper().Contains(n.ToUpper()));
		}


		


    }
}

