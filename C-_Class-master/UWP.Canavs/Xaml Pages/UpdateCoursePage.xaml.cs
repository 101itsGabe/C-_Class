using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Canavs.Dialogs;
using UWP.Canavs.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
    }
}
