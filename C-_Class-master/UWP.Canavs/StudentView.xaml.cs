using Objects.Models;
using Objects.Services;
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
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Canavs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentView : Page
    {
        public StudentView()
        {
            this.InitializeComponent();
            DataContext = new StudentViewModel();
        }

        private void Seacrh_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as StudentViewModel).SearchStudent();
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersonModel cpm = new CurrentPersonModel((DataContext as StudentViewModel).curPerson);
            this.Content= new CurrentPersonPage(cpm);
            
        }

        
    }
}
