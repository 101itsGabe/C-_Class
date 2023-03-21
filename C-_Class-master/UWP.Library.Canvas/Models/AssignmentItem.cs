using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class AssignmentItem : ContentItem
    {
        public Assignment Assignment;

        public AssignmentItem() 
        {
            Assignment= new Assignment();
        }
    }
}
