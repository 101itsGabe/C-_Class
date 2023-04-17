using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class TeachingAssistant : Instructor
    {
        public TeachingAssistant() { Courses = new List<Course>(); }  
        public TeachingAssistant(Person p) : base(p)
        {
            Name = p.Name;
            Id= p.Id;
            Courses = new List<Course>();
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - TA";
        }
    }
}
