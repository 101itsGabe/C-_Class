using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace UWP.Canavs.ViewModels
{
    public class CurrentPersonModel
    {
        public Student curPerson { get; set; }
        public ObservableCollection<Course> courses;
        public CurrentPersonModel(Person p)
        {
            if(p == null)
                p = new Student();
            curPerson= (Student)p;
            courses = new ObservableCollection<Course>(curPerson.Courses);
        }

        public ObservableCollection<Course> Courses
        {
            get { return courses; }
            private set
            { Courses = value; }
        }


    }
}
