using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class StaffViewGrades : Page
    {
        public StaffViewGrades(Course c)
        {
            this.InitializeComponent();
            DataContext = new StaffViewGradesViewModel(c);
        }


        private void RefreshPage_Click(object sender, RoutedEventArgs e)
        {
            //(DataContext as StaffViewGradesViewModel).AssignmentRefresh();
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(sender.GetType().Name);
            //(DataContext as StaffViewGradesViewModel).CurPoints = (sender as TextBox).Text;
            //(DataContext as StaffViewGradesViewModel).AddGrade();
        }

        private void GradeEnter_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                (DataContext as StaffViewGradesViewModel).AddGrade((sender as TextBox).Text);
            }

        }
    }
}
