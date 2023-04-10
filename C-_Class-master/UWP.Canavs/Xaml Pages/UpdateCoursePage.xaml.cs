using Objects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Canavs.Dialogs;
using UWP.Canavs.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Canavs.Xaml_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateCoursePage : Page
    {
        public UpdateCoursePage(UpdateCourseViewModel u)
        {
            this.InitializeComponent();
            DataContext = u;
        }

        public UpdateCoursePage()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        private void AddAssignmentGroup_Click(object sender, RoutedEventArgs e)
        {
            
            AssignmentGroupViewModel agvm = new AssignmentGroupViewModel((DataContext as UpdateCourseViewModel).curCourse);
            this.Content = new AssignmentGroupsPage(agvm);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainPage();
        }

        private void Assignments_Click(object sender, RoutedEventArgs e)
        {
            AssignmentViewModel avm = new AssignmentViewModel((DataContext as UpdateCourseViewModel).curCourse);
            this.Content = new AssignmentsPage(avm);
        }

        private void Roster_Click(object sender, RoutedEventArgs e)
        {
            RosterViewModel rvm = new RosterViewModel((DataContext as UpdateCourseViewModel).curCourse);
            this.Content = new RosterPage(rvm);
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as UpdateCourseViewModel).GradesViewChoice();

        }

        private void ViewGradesPerson_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as UpdateCourseViewModel).curPerson.GetType() == typeof(Student))
              this.Content = new StudentGradesListPage((DataContext as UpdateCourseViewModel).curPerson, (DataContext as UpdateCourseViewModel).curCourse);
            else if((DataContext as UpdateCourseViewModel).curPerson.GetType() == typeof(Instructor))
            {
                this.Content = new StaffViewGrades((DataContext as UpdateCourseViewModel).curCourse);
            }
        }
    }
}
