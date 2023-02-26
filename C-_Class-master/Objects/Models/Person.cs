using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Person : Item
    {
       
        public string Classification { get; set; }
        public List<string> Grades { get; set; }
        public List<Course> Courses { get; set; }

        public Person()
        {
            Classification = string.Empty;
            Courses = new List<Course>();
            Grades = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
    }
}