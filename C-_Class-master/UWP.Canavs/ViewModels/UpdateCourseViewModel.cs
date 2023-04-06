using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{
    public class UpdateCourseViewModel
    {
        public Course curCourse;
        public ObservableCollection<AssignmentGroup> assignmentGroups;
        public ObservableCollection<Assignment> assignments;
        public UpdateCourseViewModel(Course c)
        {
            curCourse = c;
            assignmentGroups = new ObservableCollection<AssignmentGroup>(c.AssignmentGroups);
            assignments = new ObservableCollection<Assignment>(c.Assignments);
        }
    }
}
