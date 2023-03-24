using Windows.UI.Xaml.Controls;
using UWP.Canavs.ViewModels;
using System.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP.Canavs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext= new MainViewModel();
            //To bind to the textbox needs to have a getter and setter
            //Have to have a setter so that keyboard input can be somewhere
        }

        private void Seacrh_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (DataContext as MainViewModel).SearchCourses();
        }

        private void AddNew_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (DataContext as MainViewModel).AddCourse();
        }

        private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            (DataContext as MainViewModel).RemoveCourse();
        }

        private void Update_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
