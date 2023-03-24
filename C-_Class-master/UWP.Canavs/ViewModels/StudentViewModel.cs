using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;
using Objects.Services;

namespace UWP.Canavs.ViewModels
{
    public class StudentViewModel
    {
        public string Query { get; set; }
        public StudentService studentService;
        public Person person { get; set; }
        public ObservableCollection<Person> people;
        private List<Person> allPeople;
        public Person curPerson { get; set; }

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
            studentService = new StudentService();
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

       

        
    }
}
