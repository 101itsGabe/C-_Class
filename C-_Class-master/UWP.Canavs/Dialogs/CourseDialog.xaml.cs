using Objects.Models;
using System.Collections.Generic;
using UWP.Canavs.ViewModels;
using Windows.UI.Xaml.Controls;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Canavs.Dialogs
{
    public sealed partial class CourseDialog : ContentDialog
    {
        public CourseDialog(ObservableCollection<Course> courses)
        {
            this.InitializeComponent();
            this.DataContext = new CourseViewModel(courses);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as CourseViewModel).AddCourse();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
