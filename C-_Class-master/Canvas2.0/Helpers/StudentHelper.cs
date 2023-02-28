using System;
using Objects.Models;
using Objects.Services;

//This is for interaction with the console NOT for application

namespace MyApp
{
	public class StudentHelper
	{
        private StudentService ss;
        private CourseService cs;

        public StudentHelper()
        {
            ss = StudentService.Current;
            cs = CourseService.Current;
        }

        public void AddOrUpdateStudent(Student? p = null)
		{
            Console.WriteLine("Persons ID: ");
            var PersonId = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Person's Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Entera a num for {n}'s classification: ");
            Console.WriteLine("1: Frehsman");
            Console.WriteLine("2: Sophmore");
            Console.WriteLine("3: Junior");
            Console.WriteLine("4: Senior");
            var c = Console.ReadLine() ?? string.Empty;

           
            bool isCreate = false;
            if (p == null)
            {
                isCreate = true;
                p = new Student();
            }
                
            p.Name = n;
            switch (c)
            {
                case "1":
                    p.Classification = PersonClassification.Freshamn;
                    break;
                case "2":
                    p.Classification = PersonClassification.Sophmore;
                    break;
                case "3":
                    p.Classification = PersonClassification.Junior;
                    break;
                case "4":
                    p.Classification = PersonClassification.Senior;
                    break;
            }


            if (isCreate)
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
            Console.WriteLine("\nStduent Course List:");
            cs.courseList.Where(c => c.Roster.Any(s => s.Name == n)).ToList().ForEach(Console.WriteLine);
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

        /*
        public void ListStudentCourses()
        {
            Console.WriteLine("Enter the student: ");
            var n = Console.ReadLine() ?? string.Empty;

            var curStudent = ss.studentList.FirstOrDefault(s => s.Name.ToUpper().Contains(n.ToUpper()));
            if(curStudent == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                curStudent.Courses.ForEach(Console.WriteLine);
            }
        }
        */

        

	}
}

