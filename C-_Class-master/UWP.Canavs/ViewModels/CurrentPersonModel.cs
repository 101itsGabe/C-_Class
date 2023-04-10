using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;
using Objects.Services;
using UWP.Canavs.Dialogs;

namespace UWP.Canavs.ViewModels
{
    public class CurrentPersonModel
    {
        public Student curPerson { get; set; }
        //private List<Course> curPersonCourses { get; set; }
        private ObservableCollection<Course> studentCourses;
        public List<Course> allCourses;
        public StudentService studentService;
        public CourseService courseService;
        public Course curCourse { get; set; }
        public CurrentPersonModel(Person p)
        {
            studentService = StudentService.Current;
            courseService= CourseService.Current;
            if (p == null)
                p = new Student();
            curPerson= (Student)p;
            allCourses = (courseService.Courses);
            studentCourses = new ObservableCollection<Course>(curPerson.Courses);
            
        }
        

        public ObservableCollection<Course> StudentCourses
        {
            get { return studentCourses; }
            private set
            { StudentCourses = value; }
            
        }


        public async void AddStudentCourse()
        {
            var dialog = new AddCourseStudentDialog(allCourses, curPerson);
            if (dialog != null)
                await dialog.ShowAsync();
            StudentCourses.Clear();
            foreach(Course c in curPerson.Courses)
            {
                StudentCourses.Add(c);
                if(!c.Roster.Contains(curPerson))
                    c.Roster.Add(curPerson);
            }
            //OnPropertyChanged(nameof(StudentCourses));
            var index = studentService.People.FindIndex(s => s.Id == curPerson.Id || s.Equals(curPerson));
            if(index >-1)
                studentService.People[index] = curPerson;
            
        }

        /*
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */


    }
}
