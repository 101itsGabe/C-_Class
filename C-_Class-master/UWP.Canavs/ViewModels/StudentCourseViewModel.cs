using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{
    public class StudentCourseViewModel
    {
        private ObservableCollection<Course> courses;
        public Course curCourse { get; set; }

        public Student curStudent { get; set; }
        
        public StudentCourseViewModel(List<Course> courses,Person p)
        {
            this.courses = new ObservableCollection<Course>(courses);
            curStudent = p as Student;
        }

        public ObservableCollection<Course> Courses
        {
            get { return courses; }
            private set
            { Courses = value; }
        }

        public void AddCourse()
        {
            curStudent.Courses.Add(curCourse);
        }


    }
}
