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

        public void addStudent(Student student)
        {
            ss.Add(student);
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
                Console.WriteLine("CREATING THE STUDENT");
                isCreate = true;
                p = new Student();
            }
                
            p.Name = n;
            switch (c)
            {
                case "1":
                    p.Classification = PersonClassification.Freshman;
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

            p.Name = n;
            if(int.TryParse(PersonId,out int pId))
                p.Id = pId;

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
            
            ss.Seacrh(n).ToList().ForEach(Console.WriteLine);   //Your not trying to assign anything so it is ok for now
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

        public void AddSubmission()
        {
            Console.WriteLine("Student Name: ");
            string n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code: ");
            string cc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Assignment ID: ");
            string aId = Console.ReadLine() ?? string.Empty;
            if(!int.TryParse(aId,out int assignID))
                return;
            
            var curCourse = cs.GetCourse(cc);
            var curStudent = ss.GetStudent(n);
            if(curCourse == null) 
            {
                Console.WriteLine("Sorry no course with that code");
                    return;
            }
            if (curStudent == null)
            {
                Console.WriteLine("Sorry no student with that name");
                return;
            }

            Console.WriteLine("Submission ID:");
            var sID = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(sID, out int id))
                ss.AddSubmission(id, n, cc, assignID);

        }

        public void ShowGrades()
        {
            Console.WriteLine("Student Name: ");
            string n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code: ");
            string cc = Console.ReadLine() ?? string.Empty;
            ss.GetGrades(n, cc).ToList().ForEach(Console.WriteLine);
        }

        

	}
}

