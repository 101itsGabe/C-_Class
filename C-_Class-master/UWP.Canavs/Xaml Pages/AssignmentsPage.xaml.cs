using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP.Canavs.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Canavs.Xaml_Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssignmentsPage : Page
    {
        public AssignmentsPage(AssignmentViewModel a)
        {
            this.InitializeComponent();
            DataContext = a;
        }

        private void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AssignmentViewModel).AddAssignment();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            UpdateCoursePage ucp = new UpdateCoursePage();
            ucp.DataContext = new UpdateCourseViewModel((DataContext as AssignmentViewModel).curCourse);
            this.Content = ucp;
        }
    }
}
