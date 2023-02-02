using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Assignment : Item
    {
        public int totalPoints { get; set; }

        public DateOnly dueDate { get; set; }
    }
}

