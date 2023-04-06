using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{

    
    public class StudentGradesListViewModel
    {
        public Student curStudent;
        public Course curCourse { get; set; }
        public ObservableCollection<Assignment> assignments;

        public StudentGradesListViewModel(Student s,Course c)
        {
            curStudent = s;
            assignments= new ObservableCollection<Assignment>();
            curCourse = c;
            if(curStudent.Grades.TryGetValue(curCourse.classCode, out List<Assignment> sal))
            {
                foreach(var a in sal) 
                {
                    assignments.Add(a);
                }
            }

        }

        public ObservableCollection<Assignment> Assignments
        { get { return assignments; } set { Assignments = value; } }

    }
}
