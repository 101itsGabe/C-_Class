using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.Models;
using Windows.ApplicationModel.Activation;

namespace UWP.Canavs.ViewModels
{
    public class AddStudentToRosterViewModel
    {
        public Course curCourse;
        public Person curPerson { get; set; }
        StudentService studentService;
        public ObservableCollection<Person> allPeople;

        public AddStudentToRosterViewModel(Course c)
        {
            curCourse = c;
            studentService = StudentService.Current;
            allPeople = new ObservableCollection<Person>();
            foreach (var p in studentService.People)
            {
                if(!curCourse.Roster.Contains(p))
                    allPeople.Add(p);
            }
        }

        public ObservableCollection<Person> AllPeople
        {
            get { return allPeople; }
            set { AllPeople = value; }
        }

        public void AddPerson()
        {
            curCourse.AddPerson(curPerson);
        }
    }
}
