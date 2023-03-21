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

        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }
        public Person()
        {
            Name = string.Empty;
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}