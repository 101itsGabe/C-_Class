using System;
using Objects.Models;
using Objects.Services;

//This is for interaction with the console NOT for application

namespace MyApp
{
	public class StudentHelper
	{
        private StudentService ss = new StudentService();

        public void CreateStudentRecord()
		{
            var newPerson = new Person();
            Console.WriteLine("Person Name: ");
            newPerson.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Person Classification: ");
            newPerson.classification = Console.ReadLine() ?? string.Empty;
            ss.Add(newPerson);
        }

        public void ListStudents()
        {
            ss.Students.ForEach(Console.WriteLine);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a name");
            var n = Console.ReadLine() ?? string.Empty;

            ss.Search(n).ToList().ForEach(Console.WriteLine);   //Your not trying to assign anything so it is ok for now
        }



		public StudentHelper()
		{

		}
	}
}

