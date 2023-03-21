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
        public void giveGrade()
        {
           
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - Instructor";
        }
    }
}
