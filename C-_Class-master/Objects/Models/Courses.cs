using System.Reflection;
using System;
using System.Linq;

namespace Objects.Models
{
    public class Course : Item
    {
        public string classCode { get; set; }
        public List<Student> Roster { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<Module> Modules { get; set; }

        public List<AssignmentGroup> AssignmentGroups { get; set; }

        public int creditHours {get; set; }

        public Course()
        {
            classCode = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            AssignmentGroups = new List<AssignmentGroup>();

        }

        public override string ToString()
        {
            return $"{Name} - {classCode} \n{Description}";
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

        public void CreateModule()
        {
            var m = new Module();
            Console.WriteLine("Enter Module Name: ");
            m.Name = Console.ReadLine() ?? string.Empty;
            Modules.Add(m);
        }

        public Module? GetModule(string n)
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