using System;
using System.Reflection.Metadata;
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
            Console.WriteLine("Course Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Class Code: ");
            var c = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter a Description: ");
            var desc = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which Students should be enrolled in this course? 'Q' to quit: ");
            var roster = new List<Student>();
            bool continueAdding = true;
            
            

            while (continueAdding)
            {
                sh.Students.Where(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())).ToList().ForEach(Console.WriteLine);

                var studName = "Q";
                if(sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                {
                    studName = Console.ReadLine() ?? string.Empty;
                }

                if (studName.Equals("Q") || !sh.Students.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                {
                    continueAdding = false;
                }
                
            }

            Console.WriteLine("Would you like top add assigments? Y N: ");
            var ar = Console.ReadLine() ?? "N";
            var assign = new List<Assignment>();
            if(ar.Equals("Y",StringComparison.InvariantCultureIgnoreCase))
            { 
                continueAdding = true;
                while(continueAdding)
                {
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
                        dueDate = dd
                    }) ;

                    Console.WriteLine("Add more assigments? Y N:");
                    ar = Console.ReadLine() ?? "N";
                    if(ar.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;
                    }
                }
            }

            bool isCreate = false;
            if (course == null)
            {
                isCreate = true;
                course = new Course();
            }

            course.Name = n;
            course.classCode = c;
            course.Description = desc;
            course.Roster = new List<Student>();
            course.Roster.AddRange( roster );
            course.Assignments = new List<Assignment>();
            course.Assignments.AddRange( assign );



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
    }
}

