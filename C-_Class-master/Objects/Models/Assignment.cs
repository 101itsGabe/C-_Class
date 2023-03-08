using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Assignment : Item
    {
        public decimal earnedPoints { get; set; }
        public decimal totalPoints { get; set; }

        public DateOnly dueDate { get; set; }

        public string AssignedGroup { get; set; }

        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }

        public Assignment()
        {
            Id = ++lastId;
        }


        public override string ToString()
        {
            return $"[{Id}] {Name} - {dueDate}";
        }
    }

}

