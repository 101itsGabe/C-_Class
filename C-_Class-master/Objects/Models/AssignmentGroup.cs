using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class AssignmentGroup : Item
    {

        public List<Assignment> assignmentGroup;
        public int weight { get; set; }

        public AssignmentGroup() 
        { 
            assignmentGroup = new List<Assignment>(); 
        }


        public void AddAssignment(Assignment a) 
        { 
            assignmentGroup.Add(a); 
        }

        public void RemoveAssignment(Assignment a) 
        { 
            assignmentGroup.Remove(a); 
        }
    }
}
