using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using MyApp;
using Objects.Models;
using Objects.Services;

namespace Canvas2._0.Helpers
{
	public class CourseHelper
    {
        private CourseService cs;
        private StudentService sh;
        public CourseHelper()
        {
            sh = StudentService.Current;
            cs = CourseService.Current;
        }

        public void AddOrUpdateCourse(Course? course = null)
		{

            bool isCreate = false;
            if (course == null)
            {
                isCreate = true;
                course = new Course();
            }

            var choice = "Y";
            if (!isCreate)
            {
                Console.WriteLine("Do you want to update the couse code? Y N");
                choice = Console.ReadLine() ?? "N";
            }
            else
                choice = "Y";

            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Class Code: ");
                course.classCode = Console.ReadLine() ?? string.Empty;
            }

            if (!isCreate)
            {
                Console.WriteLine("Do you want to update the couse name? Y N");
                choice = Console.ReadLine() ?? "N";
            }
            else
                choice = "Y";

            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Course Name: ");
                course.Name = Console.ReadLine() ?? string.Empty;
            }

            if (!isCreate)
            {
                Console.WriteLine("Do you want to update the couse descrption? Y N");
                choice = Console.ReadLine() ?? "N";
            }
            else
                choice = "Y";

            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter a Description: ");
                course.Description = Console.ReadLine() ?? string.Empty;
            }

            if (isCreate)
            {
                var roster = new List<Student>();
                var assign = new List<Assignment>();

                Console.WriteLine("Which Students should be enrolled in this course? 'Q' to quit: ");
                bool continueAdding = true;



                while (continueAdding)
                {
                    sh.Students.Where(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())).ToList().ForEach(Console.WriteLine);

                    var studName = "Q";
                    if (sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                    {
                        studName = Console.ReadLine() ?? string.Empty;
                        roster.Add(sh.Students.FirstOrDefault(s => s.Name.ToUpper() == studName.ToUpper()));
                    }

                    if (studName.Equals("Q") || !sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                    {
                        continueAdding = false;
                    }

                }

                Console.WriteLine("Would you like top add assigments? Y N: ");
                var ar = Console.ReadLine() ?? "N";
                if (ar.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = true;
                    while (continueAdding)
                    {
                        //ID
                        Console.WriteLine("ID: ");
                        var aId = Console.ReadLine() ?? string.Empty;
                        if (!int.TryParse(aId, out int aInt))
                        {
                            Console.WriteLine("Couldnt Hack it");
                        }
                        //Name
                        Console.WriteLine("Name: ");
                        var aname = Console.ReadLine() ?? string.Empty;
                        //Description
                        Console.WriteLine("Description: ");
                        var adesc = Console.ReadLine() ?? string.Empty;
                        //TotalPoints
                        Console.WriteLine("Total Points: ");
                        var tp = decimal.Parse(Console.ReadLine() ?? "100");
                        //DueDate
                        Console.WriteLine("Due Date: ");
                        var dd = DateOnly.Parse(Console.ReadLine() ?? "01/01/1900");

                        assign.Add(new Assignment
                        {
                            Name = aname,
                            Description = adesc,
                            totalPoints = tp,
                            dueDate = dd,
                            Id = aInt
                        });


                        Console.WriteLine("Add more assigments? Y N:");
                        ar = Console.ReadLine() ?? "N";
                        if (ar.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            continueAdding = false;
                        }
                    }
                }

                course.Roster = new List<Student>();
                course.Roster.AddRange(roster);
                course.Assignments = new List<Assignment>();
                course.Assignments.AddRange(assign);
                if(!course.Roster.Any())
                    Console.WriteLine("AHHHHH");
                foreach(var s in course.Roster)
                {
                    if(s != null)
                        s.Grades.Add(course.classCode, course.Assignments);
                };

            }


            if (isCreate)
                cs.Add(course);
            
        }




        public void SearchCourse(string? query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                cs.courseList.ForEach(Console.WriteLine);
                   //Your not trying to assign anything so it is ok for now
            }        
            else { cs.Search(query).ToList().ForEach(Console.WriteLine); }

            Console.WriteLine("Select a course: ");
            var code = Console.ReadLine() ?? string.Empty;

            var curCourse = cs.courseList.FirstOrDefault(c => c.classCode.Equals(code,StringComparison.InvariantCultureIgnoreCase));
            if(curCourse != null ) 
            {
                Console.WriteLine(curCourse.DetailDisplay);
            }
        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the course code: ");
            var n = Console.ReadLine() ?? string.Empty;
            SearchCourse();

            var curCourse = cs.courseList.FirstOrDefault(s => s.classCode.ToUpper().Contains(n.ToUpper()));

            if (curCourse == null)
            {
                    AddOrUpdateCourse(curCourse);
            }
            

        }

        public void RemoveStudentFromCourse()
        {
            Console.WriteLine("Enter class code: ");
            var c = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.courseList.FirstOrDefault(s => s.classCode.Contains(c));
            if (curCourse == null)
                Console.WriteLine($"{c} not found");
            else
            {
                bool isRemoving = true;
                while(isRemoving)
                { 
                    curCourse.Roster.ToList().ForEach(Console.WriteLine);
                    Console.WriteLine("Enter the student name you would like to remove 'Q' to quit: ");
                    var n = Console.ReadLine() ?? string.Empty;

                    if(n == "Q")
                    {
                        isRemoving = false;
                    }

                    else
                    {
                        var curStudent = sh.Students.FirstOrDefault(s => s.Name.ToUpper().Contains(n.ToUpper()));
                        if (curStudent == null) { Console.WriteLine("Student not found"); }
                        else
                        {
                            curCourse.Roster.Remove(curStudent);
                        }
                    }
                }
            }

        }

        /*
        public void EnterNewSubmission()
        {
            Console.WriteLine("Enter Couse ID");
            var cid = Console.ReadLine() ?? string.Empty;
            var c = cs.GetCourse(cid);
            if( c == null)
            {
                Console.WriteLine($"No Course with the Id: {cid}");
                return;
            }

            c.Roster.ForEach(Console.WriteLine);
            Console.WriteLine("Enter Student Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            var curStudent = sh.GetStudent(n);
            Console.WriteLine("Enter Assignment ID: ");
            var aId = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(aId, out int aId2))
            {
                Console.WriteLine("AHH");
            }
            Console.WriteLine("Enter Submission ID: ");
            var sId = Console.ReadLine() ?? string.Empty;
            if(!int.TryParse(sId, out int sId2))
            {
                Console.WriteLine("AHH");
            }
            Assignment curAssign;
            curAssign = c.Assignments.FirstOrDefault(a => a.Id == aId2);
            if( curAssign == null )
            {
                Console.WriteLine("Sorry no assignment with that id");
                return;
            }
            var submission = new Submission(sId2, n, curAssign, c.classCode);
            if (curStudent != null)
            {
                curStudent.Submissions.Add(submission);
                Console.WriteLine("Enter points on assignment: ");
                var points = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(points, out int points2))
                {
                    curStudent.Grades.Add(submission.Id, submission.getGrade(curAssign, points2));
                    curStudent.Submissions.Add(submission);
                }
            }
        }
        */

        public void GiveGrade()
        {
            Console.WriteLine("Student Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code:");
            var cc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Assignment ID:");
            var aId = Console.ReadLine() ?? string.Empty;
            int.TryParse(aId, out int assignID);
            Console.WriteLine("Enter the grade (decimcal):");
            var g = Console.ReadLine() ?? string.Empty;
            decimal.TryParse(g, out decimal grade);
            cs.giveGrade(cc, n, assignID, grade);
        }
    }
}

