using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Person : Item
    {
       
        public List<string> Grades { get; set; }

        public int ID { get; set; }


        public Person()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"[{ID}] - {Name}";
        }
    }
}