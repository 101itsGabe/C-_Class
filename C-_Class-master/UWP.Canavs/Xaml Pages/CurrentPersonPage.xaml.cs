using Objects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Canavs.ViewModels;
using UWP.Canavs.Xaml_Pages;
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

namespace UWP.Canavs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentPersonPage : Page
    {
        public CurrentPersonPage(CurrentPersonModel cpm)
        {
            this.InitializeComponent();
            if (cpm == null)
            {
                Person p = new Person(); 
                cpm = new CurrentPersonModel(p);
            }
            DataContext= cpm;
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CurrentPersonModel).AddStudentCourse();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
            this.Content = new StudentView();
        }

        private void ViewGrades_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new StudentGradesListPage((DataContext as CurrentPersonModel).curPerson, (DataContext as CurrentPersonModel).curCourse);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            (DataContext as CurrentPersonModel).setSem(rb.Name);
        }

        private void Seacrh_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CurrentPersonModel).SearchYear();
        }
    }
}
