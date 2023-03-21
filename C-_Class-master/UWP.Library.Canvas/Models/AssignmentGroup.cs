using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class AssignmentGroup : Item
    {

        public List<Assignment> Assignments;
        public decimal weight { get; set; }
        public decimal curPoints { get; set; }
        public decimal totalPoints { get; set; }

        public AssignmentGroup() 
        { 
            Assignments = new List<Assignment>(); 
        }


        public void AddAssignment(Assignment a) 
        { 
            Assignments.Add(a); 
        }

        public void RemoveAssignment(Assignment a) 
        { 
            Assignments.Remove(a); 
        }
    }
}
