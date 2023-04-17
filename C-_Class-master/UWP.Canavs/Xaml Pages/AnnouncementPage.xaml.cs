using Objects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class AnnouncementPage : Page
    {
        public AnnouncementPage(Course c)
        {
            this.InitializeComponent();
            DataContext = new AnnouncementViewModel(c);
        }

        private void AddAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AnnouncementViewModel).AddAnnouncement();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            UpdateCoursePage ucp = new UpdateCoursePage();
            ucp.DataContext = new UpdateCourseViewModel((DataContext as AnnouncementViewModel).curCourse);
            this.Content = ucp;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
