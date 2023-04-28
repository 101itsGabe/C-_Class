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
        public string curSem;
        public string Query { get; set; }
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
            get 
            { 
                return studentCourses ; 
            }
            private set
            { StudentCourses = value; }
            
        }

        public void setSem(string n)
        {
            curSem = n;
            switch (n)
            {
                case "F":
                    studentCourses.Clear();
                    courseService.Courses.ForEach(c =>
                    {
                        if (c.Semester == CourseSemester.Fall && Query == string.Empty || c.Semester == CourseSemester.Fall && c.courseYear.ToString() == Query)
                        {
                            studentCourses.Add(c);
                        }
                    });
                    break;

                case "SP":
                    studentCourses.Clear();
                    courseService.Courses.ForEach(c =>
                    {
                        if (c.Semester == CourseSemester.Spring && Query == string.Empty || c.Semester == CourseSemester.Spring && c.courseYear.ToString() == Query)
                        {
                            studentCourses.Add(c);
                        }
                    });
                    break;

                case "S":
                    studentCourses.Clear();
                    courseService.Courses.ForEach(c =>
                    {
                        if (c.Semester == CourseSemester.Summer && Query == string.Empty || c.Semester == CourseSemester.Summer && c.courseYear.ToString() == Query )
                        {
                            studentCourses.Add(c);
                        }
                    });
                    break;

                case "A":
                    studentCourses.Clear();
                    courseService.Courses.ForEach(c =>{ studentCourses.Add(c); });
                    break;
            }

        }

        public void SearchYear()
        {
            if (Query != string.Empty)
            {
                if (int.TryParse(Query, out int year))
                {
                    var searchResult = allCourses.Where(c => c.courseYear.Equals(year));
                    studentCourses.Clear();
                    foreach (var course in searchResult)
                    {
                        if (course.Semester.ToString() == curSem || curSem == "A")
                            studentCourses.Add(course);
                        else if (curSem == string.Empty || curSem == null)
                            studentCourses.Add(course);
                    }
                }
            }
            else
            {
                studentCourses.Clear();
                allCourses.ForEach(c => { studentCourses.Add(c); });
            }
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

            var index = studentService.People.FindIndex(s => s.Id == curPerson.Id || s.Equals(curPerson));
            if(index >-1)
                studentService.People[index] = curPerson;
            
        }

    }
}
