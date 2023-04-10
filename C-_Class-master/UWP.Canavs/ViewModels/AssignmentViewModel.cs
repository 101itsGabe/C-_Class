using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;
using UWP.Library.Canvas.Models;

namespace UWP.Canavs.ViewModels
{
    public class AssignmentViewModel
    {
        public CourseService courseService;
        public Course curCourse;
        public Assignment curAssign { get; set; }
        public ObservableCollection<Assignment> assignments;

        public AssignmentViewModel(Course c)
        {
            curCourse = c;
            courseService = CourseService.Current;
            assignments = new ObservableCollection<Assignment>(curCourse.Assignments);
        }

        public ObservableCollection<Assignment> Assignments
        { get { return assignments; }
            private set { assignments = value; }
        }

        public async void AddAssignment()
        {
            
            var dialog = new AddAssignmentDialog(assignments, new ObservableCollection<AssignmentGroup>(curCourse.AssignmentGroups));
            dialog.Height= 200;
            if (dialog != null)
                await dialog.ShowAsync();
           
            curCourse.Assignments = assignments.ToList();
            foreach(var s in curCourse.Roster)
            {
                if (s.GetType() == typeof(Student))
                {
                    foreach (var a in curCourse.Assignments)
                    {
                        var sub = new Submission();
                        sub.Assignment = a;
                        (s as Student).Grades[curCourse.classCode].Add(sub);
                  }
                }
            }
            var index = courseService.Courses.FindIndex(c => c.classCode == curCourse.classCode);
            courseService.Courses[index] = curCourse;
            
        }


    }
}
