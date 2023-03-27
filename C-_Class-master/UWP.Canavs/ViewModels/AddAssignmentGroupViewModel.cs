using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{
    public class AddAssignmentGroupViewModel
    {
        AssignmentGroup curGroup { get; set; }
        ObservableCollection<AssignmentGroup> assignmentGroups;

        public string Name
        { get { return curGroup.Name; }
          set { curGroup.Name = value; }
        }

        public int Weight
        {
            get { return (int)curGroup.weight; }
            set { curGroup.weight = (decimal)value; }
        }


       

        public AddAssignmentGroupViewModel(ObservableCollection<AssignmentGroup> ag)
        {
            if(curGroup== null)
                curGroup = new AssignmentGroup();
            assignmentGroups= ag;
        }

        public void AddAssignmntGroup()
        {
            assignmentGroups.Add(curGroup);
        }
    }
}
