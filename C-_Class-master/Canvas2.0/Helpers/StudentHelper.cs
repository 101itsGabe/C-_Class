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
        private ListNavigator<Person> studentNavigator;

        public StudentHelper()
        {
            ss = StudentService.Current;
            cs = CourseService.Current;
            studentNavigator = new ListNavigator<Person>(ss.personList);
        }

        public void addStudent(Student student)
        {
            ss.Add(student);
        }

        public void AddOrUpdatePerson(Person? p = null)
        {
            
            Console.WriteLine("Person's Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Select One:");
            Console.WriteLine("(S)tudent:");
            Console.WriteLine("(T)A:");
            Console.WriteLine("(I)nstructor:");
            var pChoice = Console.ReadLine() ?? string.Empty;
            bool isCreate = false;

            if (pChoice.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                
                Console.WriteLine($"Entera a num for {n}'s classification: ");
                Console.WriteLine("1: Frehsman");
                Console.WriteLine("2: Sophmore");
                Console.WriteLine("3: Junior");
                Console.WriteLine("4: Senior");
                var c = Console.ReadLine() ?? string.Empty;



                Student s;
                if (p == null)
                {
                    isCreate = true;
                    s = new Student();
                }
                else
                    s = (Student)p;


                switch (c)
                {
                    case "1":
                        s.Classification = PersonClassification.Freshman;
                        break;
                    case "2":
                        s.Classification = PersonClassification.Sophmore;
                        break;
                    case "3":
                        s.Classification = PersonClassification.Junior;
                        break;
                    case "4":
                        s.Classification = PersonClassification.Senior;
                        break;
                }
                s.Name = n;
                p = s;
                
            }

            else if (pChoice.Equals("T", StringComparison.InvariantCultureIgnoreCase))
            {
                TeachingAssistant t;
                if(p == null)
                {
                    isCreate= true;
                    t = new TeachingAssistant();
                }
                else
                    t = (TeachingAssistant)p;

                t.Name = n;
                p = t;
            }

            else if (pChoice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
            {
                Instructor i;
                if (p == null)
                {
                    isCreate = true;
                    i = new Instructor();
                }
                else
                    i = (Instructor)p;

                i.Name = n;
                p = i;
            }

            if (isCreate)
                ss.Add(p);

        }

        public void NavigateStudents()
        {
            bool keepPaging = true;
            while (keepPaging) 
            {
                foreach (var pair in studentNavigator.GetCurrentPage())
                {
                   Console.WriteLine($"{pair.Key}. {pair.Value}");
                }

                if (studentNavigator.HasPreviousPage)
                {
                    Console.WriteLine("P. Previous Page");
                }

                if (studentNavigator.HasNextPage)
                {
                    Console.WriteLine("N. Next Page");
                }

                Console.WriteLine("Make a Selection");
                var selectionChoice = Console.ReadLine();
                if ((selectionChoice?.Equals("P", StringComparison.InvariantCultureIgnoreCase) ?? false)
                   || (selectionChoice?.Equals("N", StringComparison.InvariantCultureIgnoreCase) ?? false))
                {
                    //Navigate Through Pages
                    if (selectionChoice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                        studentNavigator.GoBackward();
                    else if (selectionChoice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        studentNavigator.GoForward();
                }
                else
                {
                    Console.WriteLine("Select a Student");
                    var curStud = Console.ReadLine() ?? string.Empty;
                    keepPaging = false;
                }
            }
        }

        public void ListStudents()
        {
            NavigateStudents();
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

            var curStudent = ss.GetStudent(n);

            if (curStudent == null)
            {
                AddOrUpdatePerson(curStudent);
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
            if (!int.TryParse(aId, out int assignID))
                return;

            var curCourse = cs.GetCourse(cc);
            var curStudent = ss.GetStudent(n);
            if (curCourse == null)
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
            ss.personList.ForEach(Console.WriteLine);
            Console.WriteLine("Student Name: ");
            string n = Console.ReadLine() ?? string.Empty;
            cs.courseList.ForEach((Action<Course>)delegate (Course c)
            {
                c.Roster.ForEach((Action<Person>)delegate (Person s)
                {
                    if (s != null)
                    {
                        if (s.Name.ToUpper() == n.ToUpper() && s.GetType() == typeof(Student))
                        {
                            Console.WriteLine($"{c.classCode}");
                        }
                    }
                });

            });
            Console.WriteLine("\nClass Code: ");
            string cc = Console.ReadLine() ?? string.Empty;
            ss.GetAssignment(n, cc).ToList().ForEach(a => Console.WriteLine($"{a.Name} - {a.earnedPoints}"));
        }
        public void ShowAllCourseGrades()
        {
            ss.personList.ForEach(Console.WriteLine);
            Console.WriteLine("Student Name: ");
            string n = Console.ReadLine() ?? string.Empty;
            var curStudent = ss.GetStudent(n);

            foreach (var c in cs.courseList)
            {
                if (c.Roster.Contains(curStudent))
                {
                    var g = ss.CalculateGrade(n, c.classCode);
                    char letter;
                    switch (g)
                    {
                        case var i when g > 90:
                            letter = 'A';
                            break;
                        case var i when g > 80:
                            letter = 'B';
                            break;
                        case var i when g > 70:
                            letter = 'C';
                            break;
                        case var i when g > 60:
                            letter = 'D';
                            break;
                        default:
                            letter = 'F';
                            break;

                    }
                    Console.WriteLine($"{c.classCode}- {g} {letter}");
                }

            }
        }

        public void ShowGPA()
        {
            ss.personList.ForEach(Console.WriteLine);
            Console.WriteLine("Student Name: ");
            string n = Console.ReadLine() ?? string.Empty;
            var curStudent = ss.GetStudent(n);
            List<decimal> temp = new List<decimal>();
            int totalUnits = 0;
            decimal tgp = 0;
            foreach (var c in cs.courseList)
            {
                if (c.Roster.Contains(curStudent))
                {

                    var g = ss.CalculateGrade(n, c.classCode);

                    
                    switch (g)
                    {
                        
                        case var i when g > 90:
                            tgp += c.creditHours * 4;
                            break;
                        case var i when g > 80:
                            tgp += c.creditHours * 3;
                            break;
                        case var i when g > 70:
                            tgp += c.creditHours * 2;
                            break;
                        case var i when g > 60:
                            tgp += c.creditHours * 1;
                            break;
                        default:
                            break;

                    }
                    temp.Add(tgp);
                    totalUnits += c.creditHours;
                }
            }

            decimal gpa = 0;

            temp.ForEach(g => gpa += g);

            Console.WriteLine($"GPA: {Math.Round((decimal)(gpa / totalUnits),4)}");


        }
    }
}

