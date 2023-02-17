using System;
using Objects.Models;

namespace Objects.Services
{
	public class StudentService
	{
		public List<Person> studentList { get; set; } = new List<Person>();

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

