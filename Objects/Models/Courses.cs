using System.Reflection;
using System;

namespace Objects.Models
{
    public class Course: Item
    {
        public Course()
        {
            roster = new List<Person>();
            assignments = new List<Assignment>();
            modules = new List<Module>();
        }
        public string classCode { get; set; }
        public List<Person> roster { get; set; }

        public List<Assignment> assignments { get; set; }

        public List<Module> modules { get; set; }

        public virtual string Display => $"Course: {Name} \nClass Code:{classCode} \nDescription: {Description}";
    }
}