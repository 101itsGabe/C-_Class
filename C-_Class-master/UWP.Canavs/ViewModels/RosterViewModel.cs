using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;

namespace UWP.Canavs.ViewModels
{
    public class RosterViewModel
    {
        public Course curCourse;
        public ObservableCollection<Person> roster;
        public Person curPerson { get; set; }
        public CourseService courseService;


        public RosterViewModel(Course c)
        {
            courseService = CourseService.Current;
            curCourse= c;
            roster = new ObservableCollection<Person>(c.Roster);
        }

        public ObservableCollection<Person> Roster
        {
            get { return roster; }
            set { Roster = value; }
        }

       public async void AddToRoster()
        {
            var dialog = new AddStudentToRosterDialog(curCourse);
            dialog.Height = 200;
            if (dialog != null)
                await dialog.ShowAsync();

            var index = courseService.Courses.FindIndex(c => c.classCode == curCourse.classCode);
            courseService.Courses[index] = curCourse;
            Roster.Clear();
            foreach(var p in curCourse.Roster) 
            {
                Roster.Add(p);
            }
        }

        public void DeleteFromRoster()
        {
            if(curPerson.GetType() == typeof(Student))
            {
                (curPerson as Student).Courses.Remove(curCourse);
                (curPerson as Student).Grades.Remove(curCourse.classCode);
            }
            curCourse.Roster.Remove(curPerson);
            Roster.Clear();
            curCourse.Roster.ForEach(p => { Roster.Add(p); });
        }
    }
}
