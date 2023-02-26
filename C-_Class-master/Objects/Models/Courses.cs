using System.Reflection;
using System;

namespace Objects.Models
{
    public class Course: Item
    {
        public string classCode { get; set; }
        public List<Person> Roster { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<Module> Modules { get; set; }

        public Course()
        {
            classCode = string.Empty;
            Name = string.Empty;
            Description= string.Empty;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public override string ToString()
        {
            return $"{Name} - {classCode} \n {Description}";
        }

    }
}