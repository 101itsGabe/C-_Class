using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Objects.Models;
using Objects.Services;
using UWP.Canavs.Dialogs;
using UWP.Library.Canvas.Database;
using UWP.Library.Canvas.DTO;
using UWP.Library.Canvas.Util;
using Windows.Data.Json;

namespace UWP.Canavs.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public string Query { get; set; }
        public StudentService studentService;
        public CourseService courseService;
        public Person person { get; set; }
        public ObservableCollection<Person> people;
        private List<Person> allPeople;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person curPerson { get; set; }
        

        public IEnumerable<PersonDTOViewModel> peopleList
        { 
            get
            {
                //return DatabaseContext.Students.Select(s => new StudentDTO(s)).ToList();
                //Contact with the server
                var payload = new WebRequestHandler().Get("http://localhost:5084/Person").Result;
                //Deseralizing DTO
                var returnVal = JsonConvert.DeserializeObject<List<PersonDTO>>(payload).Select(d => new PersonDTOViewModel(d));
                OnPropertyChanged();
                return returnVal;
            }
        }


   

        public string Name
        {
            get { return person.Name; }
            set { person.Name = value; }
        }
        public int Id
        { 
            get { return person.Id; } 
        }

        public StudentViewModel()
        {
            courseService = CourseService.Current;
            studentService = StudentService.Current;
            allPeople = studentService.People;
            people = new ObservableCollection<Person>(studentService.People);
            
        }

        

        public ObservableCollection<Person> People
        {
            get { return people; }
            private set { People = value; }
        }

        public void SearchStudent()
        {
            var search = allPeople.Where(c => c.Id.ToString().Contains(Query) || c.Name.ToUpper().Contains(Query.ToUpper())).ToList();
            People.Clear();
            foreach (var person in search) 
            { People.Add(person); }
        }


        public void DeletePerson()
        {
            foreach(var c in courseService.Courses)
            {
                if(c.Roster.Contains(curPerson))
                    c.Roster.Remove(curPerson);
            }
            People.Remove(curPerson);
            allPeople.Clear();
            allPeople.AddRange(People);
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
