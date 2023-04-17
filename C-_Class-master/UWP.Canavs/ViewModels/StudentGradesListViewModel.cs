using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Library.Canvas.Models;

namespace UWP.Canavs.ViewModels
{

    
    public class StudentGradesListViewModel
    {
        public Student curStudent;
        public Course curCourse { get; set; }
        public ObservableCollection<Submission> submissions;

        public string CourseName
        {
            get { return curCourse.Name; }
            set { CourseName = value; }
        }

        public string CourseSem
        {
            get { return curCourse.Semester.ToString(); }
            set { CourseSem = value; }
        }
        public string Grade
        {
            get { return curStudent.CalculateGrade(curCourse).ToString(); }
            set { Grade= value.ToString(); }
        }

        public StudentGradesListViewModel(Student s,Course c)
        {
            curStudent = s;
            curCourse = c;
            if(curStudent.Grades.TryGetValue(curCourse.classCode,out List<Submission> sub)) { }
                submissions = new ObservableCollection<Submission>(sub);
            
        }

        public ObservableCollection<Submission> Submissions
        { get { return submissions; } set { Submissions = value; } }

        
    }
}
