using Objects.Services;
using Objects.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using UWP.Canavs.Dialogs;
using Windows.Devices.Display.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UWP.Canavs.ViewModels
{
    public class MainViewModel
    {
        public CourseService courseService;
        public string Query { get; set; }
        public Course curCourse { get; set; }
        private List<Course> allCourses;
        private ObservableCollection<Course> courses;

        public MainViewModel() 
        {
            courseService = CourseService.Current;
            allCourses = courseService.Courses;
            courses = new ObservableCollection<Course>(courseService.Courses);
        }

       

        public ObservableCollection<Course> Courses
        {
            get{ return courses;  }
            private set
            { Courses = value; }
        }

        public void  SearchCourses()
        {
            var searchResult = allCourses.Where(c => c.classCode.Contains(Query) || c.Name.ToUpper().Contains(Query.ToUpper())).ToList();
            Courses.Clear();
            
            foreach(var course in searchResult) 
            {
                Courses.Add(course);
            }    
           
        }

        public async void AddCourse()
        {
            var dialog = new CourseDialog(Courses);
            if(dialog != null)
                await dialog.ShowAsync();
            allCourses.Clear();
            allCourses.AddRange(Courses);

        }


        public void RemoveCourse()
        {
                Courses.Remove(curCourse);
                allCourses.Clear();
                allCourses.AddRange(Courses);
        }

        

        

    }
}
