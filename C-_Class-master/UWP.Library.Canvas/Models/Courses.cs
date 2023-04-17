using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using UWP.Library.Canvas.Models;

namespace Objects.Models
{
    public class Course : Item
    {
        public CourseSemester Semester { get; set; }
        public string classCode { get; set; }
        public List<Person> Roster { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<Module> Modules { get; set; }

        public List<AssignmentGroup> AssignmentGroups { get; set; }

        public List<Announcement> Announcements { get; set; }
        public int creditHours {get; set; }
        public int courseYear { get; set; }
        public int roomLocation { get; set; }

        public Course()
        {
            classCode = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            AssignmentGroups = new List<AssignmentGroup>();
            Announcements = new List<Announcement>();

        }

        public override string ToString()
        {
            return $"{Name} - {classCode}: {Semester} - {courseYear}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description}" +
                       $"\n\nRoster:\n{string.Join("\n", Roster.Select(s => s.ToString()).ToArray())} \n\n" +
                       $"Assignments:\n{string.Join("\n", Assignments.Select(a => a.ToString()).ToArray())}";
            }
        }

        
        public void AddPerson(Person curPerson)
        {
            if (curPerson != null && !Roster.Contains(curPerson))
            {
                Roster.Add(curPerson);
                if (curPerson is Student)
                {
                    (curPerson as Student).Courses.Add(this);
                    (curPerson as Student).Grades.Add(classCode, new List<Submission>());
                    foreach (var a in Assignments)
                    {
                        var sub = new Submission();
                        sub.Student = (curPerson as Student);
                        sub.Assignment = a;
                        if (!(curPerson as Student).Grades[classCode].Any(s => s.Assignment.Id == sub.Assignment.Id))
                            (curPerson as Student).Grades[classCode].Add(sub);
                    }

                }
                else if(curPerson is Instructor && !Roster.OfType<Instructor>().Any())
                {
                    (curPerson as Instructor).Courses.Add(this);
                }
                else if (curPerson is TeachingAssistant) 
                {
                    (curPerson as TeachingAssistant).Courses.Add(this);
                }

            }
        }

        public void RemovePerson(Person curPerson)
        {
            if (curPerson != null && Roster.Contains(curPerson))
            {
                Roster.Remove(curPerson);
            }
        }

        public void CreateModule()
        {
            var m = new Module();
            Console.WriteLine("Enter Module Name: ");
            m.Name = Console.ReadLine() ?? string.Empty;
            Modules.Add(m);
        }

        public Module GetModule(string n)
        {
            return Modules.FirstOrDefault(m => m.Name.ToUpper() == n.ToUpper());
        }

        public void UpdateModle (string n)
        {
            var m = GetModule(n);
            Console.WriteLine("Enter New Module Name: ");
            if(m != null)
                m.Name = Console.ReadLine() ?? string.Empty;
        }

        public void DeleteModule(string n)
        {
            var m = GetModule(n);
            if (m != null)
                Modules.Remove(m);

        }

        public void CreateAssignmentGroup(string n)
        {
            var curGroup = new AssignmentGroup();
            curGroup.Name = n;
            AssignmentGroups.Add(curGroup);
        }

        public void AddAssignmentToGroup(string n, int aId)
        {
            var curGroup = AssignmentGroups.FirstOrDefault(g => g.Name.ToUpper() == n.ToUpper());
            var curAssignment = Assignments.FirstOrDefault(a => a.Id == aId);
            if (curGroup != null && curAssignment != null)
                curGroup.AddAssignment(curAssignment);
        }

        

        
    }
}
public enum CourseSemester
{
    Fall = 0,
    Spring = 1,
    Summer = 2,
}