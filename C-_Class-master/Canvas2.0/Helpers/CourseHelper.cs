using System;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;
using MyApp;
using Objects.Models;
using Objects.Services;

namespace Canvas2._0.Helpers
{
	public class CourseHelper
    {
        private CourseService cs;
        private StudentService sh;
        private ListNavigator<Course> courseNavigator;
        public CourseHelper()
        {
            sh = StudentService.Current;
            cs = CourseService.Current;
            courseNavigator = new ListNavigator<Course>(cs.courseList);
        }

        public void AddOrUpdateCourse(Course? course = null)
		{

            bool isCreate = false;
            
                var choice = "Y";
            if (cs.courseList.Any())
            {
                Console.WriteLine("Do you want to update a couse? Y N");
                choice = Console.ReadLine() ?? "N";
                if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    cs.courseList.ForEach(Console.WriteLine);
                }
                else
                {
                    choice = "Y";
                    isCreate= true;
                    course = new Course();
                }
            }
            else
            {
                isCreate = true;
                course = new Course();
            }
            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                bool redo = true;
                while (redo)
                {
                    Console.WriteLine("Class Code: ");
                    var cc = Console.ReadLine() ?? string.Empty;
                    
                    if (!cs.courseList.Any())
                    {
                        course.classCode = cc;
                        redo = false;
                    }
                    else
                    {
                       
                        if (cs.courseList.FindIndex(c => c.classCode == cc) == -1 && isCreate)
                        {
                            course.classCode = cc;
                            redo = false;
                        }
                        else if(cs.courseList.FindIndex(c => c.classCode == cc) >= 0 && !isCreate)
                        {
                            course = cs.GetCourse(cc);
                            course.classCode = cc;
                            redo = false;
                        }
                        else
                        {
                            Console.WriteLine("A Class with that code already exists...");
                        }
                        

                    }
                }
                

                
            }

            
            if (!isCreate)
            {
                Console.WriteLine("Do you want to update the couse code? Y N");
                choice = Console.ReadLine() ?? "N";
                if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Course Code: ");
                    course.classCode = Console.ReadLine() ?? string.Empty;
                }
                else
                    choice = "Y";
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

            if (!isCreate)
            {
                Console.WriteLine("Do you want to update the credit hours? Y N");
                choice = Console.ReadLine() ?? "N";
            }
            else
                choice = "Y";

            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Credit Hours: ");
                var credit = Console.ReadLine() ?? string.Empty;
                int.TryParse(credit, out int creditHours);
                course.creditHours = creditHours;
            }



            if (isCreate)
            {
                var roster = new List<Person>();
                var assign = new List<Assignment>();
                var assignmentgroup = new List<AssignmentGroup>();
                var moduleGroup = new List<Module>();

                Console.WriteLine("Which People should be enrolled in this course? 'Q' to quit: ");
                bool continueAdding = true;



                while (continueAdding)
                {
                    foreach(var p in sh.personList)
                    {
                        if (!roster.Contains(p))
                        {
                            Console.WriteLine(p);
                        }
                    }

                    var studName = "Q";
                    if (sh.personList.Any(s => !roster.Any(sn => s.Name.ToUpper() == sn.Name.ToUpper())))
                    {
                        studName = Console.ReadLine() ?? string.Empty;
                        var curStudent = sh.People.FirstOrDefault(p => p.Name.ToUpper() == studName.ToUpper());
                        roster.Add(curStudent);
                        Console.WriteLine('\n');
                    }

                    if (studName.Equals("Q") || !sh.personList.Any())
                    {
                        continueAdding = false;
                    }

                }

                course.Roster = new List<Person>();
                course.Roster.AddRange(roster);

                Console.WriteLine("Woudl you like to Add Assignment Groups? Y N");
                var ag = Console.ReadLine() ?? string.Empty;
                if (ag.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = true;
                    while (continueAdding)
                    {
                        
                        Console.WriteLine("Assignment Group Name: ");
                        var aName = Console.ReadLine() ?? string.Empty;

                        
                        Console.WriteLine("Add more assigments groups? Y N:");
                        ag = Console.ReadLine() ?? "N";
                        if (ag.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            continueAdding = false;
                        }
                        
                        assignmentgroup.Add(new AssignmentGroup{ Name = aName});



                        
                    }

                    Console.WriteLine("Set the weights for each of the classes");
                    int l = assignmentgroup.Count();
                    int curPercent = 100;           //Current precent of class wight
                    List<AssignmentGroup?> tempList = new List<AssignmentGroup>(assignmentgroup);
                    while (tempList.Any()) 
                    {
                        Console.WriteLine($"Current Percent: {curPercent}%");
                        tempList.ForEach(g => Console.WriteLine(g.Name));
                        Console.WriteLine("Chose a Group to add a weight: ");
                        var group = Console.ReadLine() ?? string.Empty;
                        var curGroup = tempList.FirstOrDefault(g => g.Name == group);
                        Console.WriteLine("Enter a Percent Weight: ");
                        var w = Console.ReadLine() ?? string.Empty;
                        decimal.TryParse(w, out decimal curWieght);
                        if(curGroup != null)
                            curGroup.weight = curWieght;
                        curPercent -= (int)curWieght;
                        tempList.Remove(curGroup);

                        
                    }

                    course.AssignmentGroups = new List<AssignmentGroup>();
                    course.AssignmentGroups.AddRange(assignmentgroup);
                }

                Console.WriteLine("Would you like to add assigments? Y N: ");
                var ar = Console.ReadLine() ?? "N";
                if (ar.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = true;
                    while (continueAdding)
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

                        var curAssign = new Assignment
                        {
                            Name = aname,
                            Description = adesc,
                            totalPoints = tp,
                            dueDate = dd,
                            
                        };

                        assign.Add(curAssign);

                        Console.WriteLine("Which Group would you like to add this Assignment to?");
                        assignmentgroup.ForEach(a => Console.WriteLine(a.Name));
                        ar = Console.ReadLine() ?? string.Empty;
                        var curGroup = assignmentgroup.FirstOrDefault(a => a.Name.ToUpper() == ar.ToUpper());
                        if(curGroup == null) { Console.WriteLine("Oh Brother");  }
                        if (curGroup != null)
                        {
                            curAssign.AssignedGroup = curGroup.Name;
                            curGroup.AddAssignment(curAssign);
                            curGroup.totalPoints += curAssign.totalPoints;
                        }


                        Console.WriteLine("Add more assigments? Y N:");
                        ar = Console.ReadLine() ?? "N";
                        if (ar.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            continueAdding = false;
                        }
                    }

                    course.Assignments = new List<Assignment>();
                    course.Assignments.AddRange(assign);
                }

                Console.WriteLine("Would you like to add modules? Y N: ");
                ar = Console.ReadLine() ?? "N";
               
                if (ar.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = true;
                    while (continueAdding)
                    {
                        if(course != null)
                            moduleGroup.Add(CreateModule(course));
                        Console.WriteLine("Add More Modules? Y N");
                        ar = Console.ReadLine() ?? "N";
                        if(ar.Equals("N"))
                            continueAdding= false;
                    }

                    course.Modules= new List<Module>();
                    course.Modules.AddRange(moduleGroup);

                }

                
                

                foreach(var p in course.Roster)
                {
                    if (p != null && p.GetType() == typeof(Student))
                    {
                        var curStudent =  (Student)p;
                        curStudent.Grades.Add(course.classCode, course.Assignments);
                    }
                };

                

            }
            

            if (isCreate)
                cs.Add(course);

        }


        public void NavigateCourses()
        {
            bool keepPaging = true;
            while (keepPaging)
            {
                foreach (var pair in courseNavigator.GetCurrentPage())
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }

                if (courseNavigator.HasPreviousPage)
                {
                    Console.WriteLine("P. Previous Page");
                }

                if (courseNavigator.HasNextPage)
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
                        courseNavigator.GoBackward();
                    else if (selectionChoice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        courseNavigator.GoForward();
                }
                else
                {
                    Console.WriteLine("Select a Student");
                    var curStud = Console.ReadLine() ?? string.Empty;
                    keepPaging = false;
                }
            }
        }

        public void ListAllCourses()
        {
            NavigateCourses();
        }




        public void SearchCourse()
        { 

            Console.WriteLine("Select a course: ");
            var code = Console.ReadLine() ?? string.Empty;

            var curCourse = cs.courseList.FirstOrDefault(c => c.classCode.Equals(code,StringComparison.InvariantCultureIgnoreCase));

            if(curCourse != null ) 
            {
                Console.WriteLine($"{curCourse.Name}");
                Console.WriteLine($"{curCourse.classCode}");
                Console.WriteLine("Roster:");
                curCourse.Roster.ForEach(Console.WriteLine);
                Console.WriteLine("Assignment Groups");
                curCourse.AssignmentGroups.ForEach(a => Console.WriteLine(a.Name));
                Console.WriteLine("Modules");
                curCourse.Modules.ForEach(m => Console.WriteLine(m.Name));
                //Console.WriteLine(curCourse.DetailDisplay);
            }
        }

        
        public void AddStudentToCourse()
        {
            cs.courseList.ForEach(c => Console.WriteLine(c.classCode));
            Console.WriteLine("Enter class code: ");
            var c = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.courseList.FirstOrDefault(s => s.classCode.Contains(c));
            if (curCourse != null)
            {
                sh.personList.ForEach(a =>
                {
                    if (a.GetType() == typeof(Student) && !curCourse.Roster.Contains(a))
                    {
                        Console.WriteLine(a);
                    }
                });

                Console.WriteLine("Enter the name of the student you would like to add:");
                var name = Console.ReadLine() ?? string.Empty;
                var curStudent = curCourse.Roster.FirstOrDefault(s => s.Name.ToUpper() == name.ToUpper());
                if(curStudent != null) 
                {
                    curCourse.Roster.Add(curStudent);
                }
            }
        }

        public void RemoveStudentFromCourse()
        {
            cs.courseList.ForEach(c => Console.WriteLine(c.classCode));
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
                        var curStudent = sh.GetStudent(n);
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
            Console.WriteLine("Courses: ");
            cs.courseList.ForEach(c => Console.WriteLine(c.classCode));
            Console.WriteLine("Class Code:");
            var cc = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cc);
            if (curCourse == null)
                return;
            
            foreach (var p in curCourse.Roster)
            {
                if (p != null)
                {
                    if (p.GetType() == typeof(Student))
                        Console.WriteLine(p.ToString());
                }
            }
            Console.WriteLine("Student Name: ");
            var n = Console.ReadLine() ?? string.Empty;
            curCourse.Assignments.ForEach(a => Console.WriteLine($"{a.Name} - {a.Id}"));
            Console.WriteLine("Assignment ID:");
            var aId = Console.ReadLine() ?? string.Empty;
            int.TryParse(aId, out int assignID);
            var cAssign = curCourse.Assignments.FirstOrDefault(a => a.Id == assignID);
            if (cAssign != null)
                Console.WriteLine($"Total Points: {cAssign.totalPoints}");
            Console.WriteLine("Enter the grade (decimcal):");
            var g = Console.ReadLine() ?? string.Empty;
            decimal.TryParse(g, out decimal grade);
            cs.giveGrade(cc, n, assignID, grade);


        }

        //Announcements

        public void CreateAnnouncement()
        {
            
            cs.courseList.ForEach(cs=> Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Announcement Name: ");
            var aName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Announcement Description: ");
            var aDesc = Console.ReadLine() ?? string.Empty;
            cs.CreateAndUpdateAnnouncement(cCode,aName, aDesc);
        }

        public void ShowAnnouncement()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            if(curCourse != null) 
                curCourse.Announcements.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Select an Announcement: ");
            var aName = Console.ReadLine() ?? string.Empty;
            var curAnnon =  curCourse.Announcements.FirstOrDefault(a => a.Name == aName);
            Console.WriteLine(curAnnon.Description);
        }

        public void DeleteAnnouncement()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            if (curCourse != null)
                curCourse.Announcements.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Select an Announcement: ");
            var aName = Console.ReadLine() ?? string.Empty;
            cs.DeleteAnnouncement(cCode, aName);
        }

        public void UpdateAnnouncement()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            curCourse.Announcements.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Which Announcement would you like to update?:");
            var aName = Console.ReadLine() ?? string.Empty;
            var curAnnouncement = curCourse.Announcements.FirstOrDefault(a => a.Name == aName);
            Console.WriteLine("Announcement Name: ");
            aName = Console.ReadLine() ?? string.Empty;
            curAnnouncement.Name = aName;
            Console.WriteLine("Do you want to update the descipriton? Y N");
            var choice = Console.ReadLine() ?? string.Empty;
            if (choice == "Y")
            {
                Console.WriteLine("Announcement Description: ");
                var aDesc = Console.ReadLine() ?? string.Empty;
                cs.CreateAndUpdateAnnouncement(cCode, aName, aDesc);
            }
            else
                cs.CreateAndUpdateAnnouncement(cCode, aName, curAnnouncement.Description);
        }

        //ContentItem

        private PageItem? CreatePageItem(Course c)
        {
            Console.WriteLine("Page Name: ");
            var aName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Page Description: ");
            var mDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter a path to the file");
            var HTMLstring = Console.ReadLine() ?? string.Empty;
            return new PageItem
            {
                HTMLBody = HTMLstring,
                Name = aName,
                Description = mDesc
            };
        }

        private AssignmentItem? CreateAssginmentItem(Course c)
        {
            Console.WriteLine("Assignment Item Name: ");
            var aName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Assignment Item Description: ");
            var mDesc = Console.ReadLine() ?? string.Empty;
            c.Assignments.ForEach(a => Console.WriteLine(a));
            Console.WriteLine("Which Assignments should be added? Enter ID:");
            var aId = int.Parse(Console.ReadLine() ?? "-1");
            if(aId >= 0)
            {
                var curAssign = c.Assignments.FirstOrDefault(a => a.Id == aId);
                if (curAssign != null)
                {
                    return new AssignmentItem()
                    {
                        Assignment = curAssign,
                        Name = aName,
                        Description = mDesc
                    };
                }

            }
            //Course was null??
            return null;
        }

        private FileItem? CreateFileItem(Course c)
        {
            Console.WriteLine("Module Name: ");
            var aName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Module Description: ");
            var mDesc = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter a path to the file");
            var filePath = Console.ReadLine() ?? string.Empty;
            return new FileItem
            {
                FilePath = filePath,
                Name = aName,
                Description = mDesc
            };
        }

        


        //Modules
        public void AddNewModule()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            if(curCourse != null)
             curCourse.Modules.Add(CreateModule(curCourse));
        }
        public void DeleteModule()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            if (curCourse != null)
                curCourse.Modules.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Select a Module: ");
            var aName = Console.ReadLine() ?? string.Empty;
            cs.DeleteModule(cCode, aName);
        }

        public void UpdateModule()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            curCourse.Modules.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Which Module would you like to update?:");
            var aName = Console.ReadLine() ?? string.Empty;
            var curMod = curCourse.Modules.FirstOrDefault(a => a.Name == aName);
            Console.WriteLine("Module Name: ");
            aName = Console.ReadLine() ?? string.Empty;
            curMod.Name = aName;
            Console.WriteLine("Do you want to update the descipriton? Y N");
            var choice = Console.ReadLine() ?? string.Empty;
            if (choice == "Y")
            {
                Console.WriteLine("Module Description: ");
                var aDesc = Console.ReadLine() ?? string.Empty;
                cs.CreateAndUpdateModule(cCode, aName);
            }
            else
                cs.CreateAndUpdateModule(cCode, aName);
            Console.WriteLine("Would you like to add or remove content items? Y N");
            choice = Console.ReadLine() ?? string.Empty;
            if(choice.ToUpper() == "Y") 
            {
                curMod.ContentItems.ForEach(a => Console.WriteLine(a.Name));
                Console.WriteLine("Enter the name of the item you want to remove or enter A to add: ");
                choice = Console.ReadLine() ?? string.Empty;
                if (choice.ToUpper() == "A")
                {
                    bool keepAdding = true;
                    while (keepAdding)
                    {
                        Console.WriteLine("What type of content would you like to add?");
                        Console.WriteLine("1. Assignment");
                        Console.WriteLine("2. File");
                        Console.WriteLine("3. Page");
                        var contentChoice = int.Parse(Console.ReadLine() ?? "0");

                        switch (contentChoice)
                        {
                            case 1:
                                var newAssignmentContent = CreateAssginmentItem(curCourse);
                                if (newAssignmentContent != null)
                                    curMod.ContentItems.Add(newAssignmentContent);
                                break;
                            case 2:
                                var newFileContent = CreateFileItem(curCourse);
                                if (newFileContent != null)
                                    curMod.ContentItems.Add(newFileContent);
                                break;

                            case 3:
                                var newPageContent = CreatePageItem(curCourse);
                                if (newPageContent != null)
                                    curMod.ContentItems.Add(newPageContent);
                                break;

                            default:
                                break;

                        }

                        Console.WriteLine("Would you like to add content? Y N");
                        choice = Console.ReadLine() ?? string.Empty;
                        if(choice.ToUpper() == "N")
                            keepAdding = false;
                    }
                }
                else
                {
                    var curContentItem = curMod.ContentItems.FirstOrDefault(c => c.Name.ToUpper() == choice.ToUpper());
                    if(curContentItem!= null)
                        curMod.ContentItems.Remove(curContentItem);
                }
            }
        }

        public void ShowModule()
        {
            cs.courseList.ForEach(cs => Console.WriteLine(cs.classCode));
            Console.WriteLine("Class Code");
            var cCode = Console.ReadLine() ?? string.Empty;
            var curCourse = cs.GetCourse(cCode);
            if (curCourse != null)
                curCourse.Modules.ForEach(a => Console.WriteLine(a.Name));
            Console.WriteLine("Select a Module: ");
            var aName = Console.ReadLine() ?? string.Empty;
            var curMod = curCourse.Modules.FirstOrDefault(a => a.Name == aName);
            if(curMod != null)
                curMod.ContentItems.ForEach(a => Console.WriteLine(a.Name));
            
        }

        private Module CreateModule(Course c)
        {

            
            Console.WriteLine("Module Name: ");
            var aName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Module Description: ");
            var mDesc = Console.ReadLine() ?? string.Empty;
            
            var Module = new Module
            {
                Name = aName,
                Description= mDesc
            };

            Console.WriteLine("Would you like to add content? Y N");
            var choice = Console.ReadLine() ?? string.Empty;
            while(choice.Equals("Y",StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What type of content would you like to add?");
                Console.WriteLine("1. Assignment");
                Console.WriteLine("2. File");
                Console.WriteLine("3. Page");
                var contentChoice = int.Parse(Console.ReadLine() ?? "0");

                switch(contentChoice) 
                {
                    case 1:
                        var newAssignmentContent = CreateAssginmentItem(c);
                        if(newAssignmentContent != null)
                            Module.ContentItems.Add(newAssignmentContent);
                        break;
                    case 2:
                        var newFileContent = CreateFileItem(c);
                        if (newFileContent != null)
                            Module.ContentItems.Add(newFileContent);
                        break;

                    case 3:
                        var newPageContent = CreatePageItem(c);
                        if (newPageContent != null)
                            Module.ContentItems.Add(newPageContent);
                        break;

                    default:
                        break;

                }

                Console.WriteLine("Would you like to add content? Y N");
                choice = Console.ReadLine() ?? string.Empty;
            }

            return Module;
        }

    }
}

