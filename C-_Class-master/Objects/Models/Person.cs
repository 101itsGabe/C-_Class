using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Person : Item
    {
       
        public string classification { get; set; }
        public List<string> grades { get; set; }
        public List<Course> courses { get; set; }

        public Person()
        {
            classification = string.Empty;
            courses = new List<Course>();
            grades = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} - {classification}";
        }
    }
}