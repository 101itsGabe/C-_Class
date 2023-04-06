using Objects.Models;
using System.Collections.ObjectModel;
using UWP.Canavs.ViewModels;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Canavs.Dialogs
{
    public sealed partial class AddAssignmentDialog : ContentDialog
    {
        public AddAssignmentDialog(ObservableCollection<Assignment> a, ObservableCollection<AssignmentGroup> ag)
        {
            this.InitializeComponent();
            DataContext = new AddAssignmentViewModel(a, ag);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as AddAssignmentViewModel).AddAssignment();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
