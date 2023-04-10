using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class TeachingAssistant : Instructor
    {
        public TeachingAssistant(Person p) : base(p)
        {
            Name = p.Name;
            Id= p.Id;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - TA";
        }
    }
}
