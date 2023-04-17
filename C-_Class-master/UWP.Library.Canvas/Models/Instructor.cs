using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Instructor : Person
    {
        public string classCode { get; set; }
        public List<Course> Courses { get; set; }
        public Instructor() 
        {
            Courses = new List<Course>();
        }

        public Instructor(Person p )
        {
            Name= p.Name;
            Id= p.Id;
            Courses = new List<Course>();
        }
        public void giveGrade()
        {
           
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - Instructor";
        }
    }
}
