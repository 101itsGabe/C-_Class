using System.Reflection;
using System;

namespace Objects.Models
{
    public class Course : Item
    {
        public string classCode { get; set; }
        public List<Student> Roster { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<Module> Modules { get; set; }

        public Course()
        {
            classCode = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public override string ToString()
        {
            return $"{Name} - {classCode} \n {Description}";
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
    }
}