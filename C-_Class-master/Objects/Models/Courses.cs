using System.Reflection;
using System;

namespace Objects.Models
{
    public class Course: Item
    {
        public string classCode { get; set; }
        public List<Person> roster { get; set; }

        public List<Assignment> assignments { get; set; }

        public List<Module> modules { get; set; }

        public Course()
        {
            classCode = string.Empty;
            Name = string.Empty;
            Description= string.Empty;
            roster = new List<Person>();
            assignments = new List<Assignment>();
            modules = new List<Module>();
        }

        public override string ToString()
        {
            return $"{Name} - {classCode} \n {Description} \n";
        }

    }
}