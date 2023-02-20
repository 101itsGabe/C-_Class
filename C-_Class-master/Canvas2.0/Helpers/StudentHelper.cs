using System;
using Objects.Models;
using Objects.Services;

//This is for interaction with the console NOT for application

namespace MyApp
{
	public class StudentHelper
	{
        private StudentService ss = new StudentService();

        public void AddOrUpdateStudent(Person? p = null)
		{
            Console.WriteLine("Person's Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"{n}'s classification: ");
            var c = Console.ReadLine() ?? string.Empty;

            bool isCreate = false;
            if (p == null)
            {
                isCreate = true;
                p = new Person();
            }
                
            p.Name = n;
            p.classification = c;

            if(isCreate)
                ss.Add(p);
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

        public void UpdateStudentRecord()
        {
            Console.WriteLine("Enter the student: ");
            var n = Console.ReadLine() ?? string.Empty;

            var curStudent = ss.studentList.FirstOrDefault(s => s.Name.ToUpper().Contains(n.ToUpper()));

            if(curStudent == null)
            {
                AddOrUpdateStudent(curStudent);
            }


        }

		public StudentHelper()
		{

		}
	}
}

