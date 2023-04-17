using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UWP.Canavs.ViewModels
{
    public class AddAssignmentViewModel
    {
        public Assignment curAssignment { get; set; }
        public AssignmentGroup curGroup { get; set; }
        public ObservableCollection<Assignment> assignments;
        public ObservableCollection<AssignmentGroup> assignmentGroups;


        public string Name
        {
            get { return curAssignment.Name; }
            set { curAssignment.Name = value; }
        }

        public int totalPoints
        {
            get { return (int)curAssignment.totalPoints; }
            set { curAssignment.totalPoints = (decimal)value; }
        }

        public ObservableCollection<Assignment> Assignments 
        { 
            get { return assignments; } 
            set { Assignments = value; }        
        }

        public DateTime dueDate
        {
            get { return curAssignment.dueDate; }
            set { curAssignment.dueDate = value; }
        }
        
        public ObservableCollection<AssignmentGroup> AssignmentGroups
        {
            get { return assignmentGroups; }
            set { AssignmentGroups = value;}
        }

        public AddAssignmentViewModel(ObservableCollection<Assignment> a, ObservableCollection<AssignmentGroup> ag)
        {
            if(curAssignment== null) 
                curAssignment = new Assignment();
            assignments= a;
            assignmentGroups= ag;
        }

        public void AddAssignment()
        {
            assignments.Add(curAssignment);
            curGroup.AddAssignment(curAssignment);
        }
}
}
