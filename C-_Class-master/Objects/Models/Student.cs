using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Student : Person
    {
        public Dictionary<int,double> Grades { get; set; }
        public PersonClassification Classification { get; set; }

        public Student() 
        {
            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
    }
}

public enum PersonClassification
{
    Freshamn = 0,
    Sophmore = 1,
    Junior = 2,
    Senior = 3
}

