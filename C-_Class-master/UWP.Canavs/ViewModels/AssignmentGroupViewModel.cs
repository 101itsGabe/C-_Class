using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;

namespace UWP.Canavs.ViewModels
{
    public class AssignmentGroupViewModel
    {
        public CourseService courseService;
        public ObservableCollection<AssignmentGroup> assignmentGroups;
        public Course curCourse;
        public AssignmentGroup curGroup { get; set; }

        public AssignmentGroupViewModel(Course c)
        {
            courseService = CourseService.Current;
            curCourse = c;
            assignmentGroups = new ObservableCollection<AssignmentGroup>(curCourse.AssignmentGroups);
        }

        public ObservableCollection<AssignmentGroup> AssignmentGroups
        {
            get { return assignmentGroups; }
            private set { AssignmentGroups = value; }
        }

        public async void AddAssignmentGroup()
        {
            var dialog = new AddAssignmentGroupDialog(assignmentGroups);
            if (dialog != null)
                await dialog.ShowAsync();
        
            OnPropertyChanged(nameof(AssignmentGroups));
            curCourse.AssignmentGroups = assignmentGroups.ToList();
            var index = courseService.Courses.FindIndex(c => c.classCode == curCourse.classCode);
            courseService.Courses[index] = curCourse;
        }

        public void RemoveAssignmentGroup()
        {
            curCourse.AssignmentGroups.Remove(curGroup);
            AssignmentGroups.Clear();
            foreach(var a in curCourse.AssignmentGroups)
            {
                AssignmentGroups.Add(a);
            }
            OnPropertyChanged(nameof(AssignmentGroups));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
