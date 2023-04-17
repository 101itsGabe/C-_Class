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
        public CourseService cs;
        public Student curStudent { get; set; }
        
        public StudentCourseViewModel(List<Course> inputCourses,Person p)
        {
            curStudent = p as Student;

            courses = new ObservableCollection<Course>();
            foreach(var c in inputCourses) 
            {
                if(!c.Roster.Contains(curStudent))
                    courses.Add(c);
            }

            
        }

        public ObservableCollection<Course> Courses
        {
            get 
            {
                return courses; 
            }
            private set
            { Courses = value; }
        }

        public void AddCourse()
        {
            curStudent.Courses.Add(curCourse);
        }


    }
}
