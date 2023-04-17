using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;

namespace UWP.Canavs.ViewModels
{
    public class UpdateCourseViewModel
    {
        public Course curCourse;
        public ObservableCollection<AssignmentGroup> assignmentGroups;
        public ObservableCollection<Assignment> assignments;
        public Person curPerson;

        public string CourseName
        { get { return curCourse.Name; } set { CourseName = value; } }
        public string CourseSem
        { get { return curCourse.Semester.ToString(); } set { CourseSem = value; } }
        public string CourseRoom
        { 
            get 
            {
                string rstring = "Room " + curCourse.roomLocation.ToString();;
                return rstring;
            } 
            set 
            { 
                CourseRoom = value; } 
        }

        public string CourseYear
        {
            get { return curCourse.courseYear.ToString(); }
            set { CourseYear = value; }
        }

        public UpdateCourseViewModel(Course c)
        {
            curCourse = c;
            assignmentGroups = new ObservableCollection<AssignmentGroup>(c.AssignmentGroups);
            assignments = new ObservableCollection<Assignment>(c.Assignments);
        }

        public async void GradesViewChoice()
        {
            var dialog = new RosterViewDialog(new ObservableCollection<Person>(curCourse.Roster));
            if (dialog != null)
            {
                await dialog.ShowAsync();
            }
            curPerson = dialog.currentPerson;
        }


    }
}
