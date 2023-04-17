using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;
using UWP.Library.Canvas.Models;

namespace UWP.Canavs.ViewModels
{
    public class AnnouncementViewModel
    {
        public Course curCourse;
        public ObservableCollection<Announcement> announcements {get; set;}

        public AnnouncementViewModel(Course c)
        {
            curCourse= c;
            announcements= new ObservableCollection<Announcement>(curCourse.Announcements);
        }

        public ObservableCollection<Announcement> Announcements 
        { 
            get { return announcements; }
            set { Announcements = value; }
        }

        public async void AddAnnouncement()
        {
            var dialog = new AddAnnouncementDialog(announcements);
            if (dialog != null)
                await dialog.ShowAsync();
            curCourse.Announcements = announcements.ToList();
            
        }
        

        


    }
}
