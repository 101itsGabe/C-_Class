using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{
    //This is one is for the Dialog
    public class RosterViewViewModel
    {
        public Person curPerson { get; set; }
        public ObservableCollection<Person> roster;

        public ObservableCollection<Person> Roster 
        {
            get { return roster; }
            set { Roster = value; }
        }

        public RosterViewViewModel(ObservableCollection<Person> p) 
        {
            roster = p;
        }
    }
}
