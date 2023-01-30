using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class Course : Item
    {
        public string classCode { get; set; }
        public List<Person> roster { get; set; }

        public List<Assignment> assignments { get; set; }

        public List<Module> modules { get; set; }

        public virtual string Display => $"Course: {Name} \nClass Code:{classCode} \nDescription: {Description}";
    }
}
