using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.Models;
using Windows.Graphics.Printing.OptionDetails;
using Windows.Media.MediaProperties;

namespace UWP.Canavs.ViewModels
{
    //Hi
    public class StaffViewGradesViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Person> studentRoster;
        public Person curPerson;
        public Course curCourse;
        public ObservableCollection<Submission> submissions;
        public string curPoints;
        public Submission CurSubmission { get; set; }

        public String CurPoints
        { get { return curPoints; }
                set { curPoints = value; }
        }

        public Person CurPerson
        {
            get { return curPerson; }
            set 
            {
                curPerson = value;  
                if((curPerson as Student).Grades.TryGetValue(curCourse.classCode,out List<Submission> s))
                {
                    submissions = new ObservableCollection<Submission>(s);
                    OnPropertyChanged(nameof(Submissions));
                }
                
            }
        }

        public void AssignmentRefresh()
        {
            if ((curPerson as Student).Grades.TryGetValue(curCourse.classCode, out List<Submission> s))
            {
                submissions = new ObservableCollection<Submission>(s);
                CurSubmission = s[0];
                CurPoints = CurSubmission.Grade.ToString();
            } 
        }
        

        public void AddGrade(string n)
        {

            if (decimal.TryParse(n, out decimal p))
            {
                (CurPerson as Student).Grades[curCourse.classCode].FirstOrDefault(s => s.Assignment.Id == CurSubmission.Assignment.Id).Grade = p;
            }
        }

        public StaffViewGradesViewModel(Course c)
        {
            curCourse = c;
            studentRoster = new ObservableCollection<Person>();
            foreach (var s in curCourse.Roster)
            {
                if(s.GetType() == typeof(Student))
                    studentRoster.Add(s);
            }

            curPerson = studentRoster[0];
            if((curPerson as Student).Grades.TryGetValue(curCourse.classCode, out List<Submission> sub))
                submissions= new ObservableCollection<Submission>(sub);
        }

        public ObservableCollection<Person> StudentRoster
        { get { return studentRoster; }
            set { StudentRoster = value; }
        }

        public ObservableCollection<Submission> Submissions 
        {
            get 
            {
                    return submissions;
            } 
            set 
            {
                if ((curPerson as Student).Grades.TryGetValue(curCourse.classCode, out List<Submission> s))
                {
                    Submissions = new ObservableCollection<Submission>(s);
                }; 
            }
        }

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
