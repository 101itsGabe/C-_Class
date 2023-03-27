using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Canavs.Dialogs;

namespace UWP.Canavs.ViewModels
{
    public class CourseViewModel
    {
        private Course course { get; set; }
        private ObservableCollection<Course> courses;
        public string Name
        {
            get
            { return course.Name; }
            set
            { course.Name = value; }
        }

        public string classCode
        {
            get { return course.classCode; }
            set { course.classCode = value; }
        }

        public CourseViewModel(ObservableCollection<Course> courses)
        {
            if(course == null)
                course= new Course();
            this.courses= courses;
        }

        public void AddCourse()
        {
            courses.Add(course);
        }

        

        
    }
}
