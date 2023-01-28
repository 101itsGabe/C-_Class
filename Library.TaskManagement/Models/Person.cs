using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class Person : Item
    {
        public string classification { get; set; }
        public List<string> grades { get; set; }
    }
}
