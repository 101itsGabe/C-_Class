using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Assignment : Item
    {
        public decimal totalPoints { get; set; }

        public DateOnly dueDate { get; set; }


        public override string ToString()
        {
            return $"{Name} - {dueDate}";
        }
    }

}

