using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace UWP.Canavs.ViewModels
{
    public class AddAnnouncementViewModel
    {
        public Announcement announcement;
        public ObservableCollection<Announcement> announcements;
        public string Name
        {
            get { return announcement.Name; }
            set { announcement.Name = value; }
        }
        public string Description
        {
            get { return announcement.Description; }
            set { announcement.Description = value; }
        }


        public AddAnnouncementViewModel(ObservableCollection<Announcement> a)
        {
            if (announcement == null)
                announcement = new Announcement();
            this.announcements = a;
        }
        public void AddAnnouncement()
        {
            announcements.Add(announcement);
        }
    }
      
}
