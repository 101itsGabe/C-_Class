using Objects.Models;
using Objects.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Canavs.ViewModels
{
    public class AddPersonViewModel
    {
        public Person curPerson { get; set; }
        public StudentService studentService;
        public ObservableCollection<Person> People;

        public AddPersonViewModel(ObservableCollection<Person> p)
        {
            studentService = StudentService.Current;
            curPerson= new Person();
            People = p;
        }

        public string Name {
            get { return curPerson.Name; }
            set { curPerson.Name = value; }
        }

        public void AddPerson()
        {
            People.Add(curPerson);
            studentService.People.Add(curPerson);
            //studentService.personList.Add(curPerson);
        }
        
        public void setPerson(string n)
        {
            if(n.Equals("F") || n.Equals("S") || n.Equals("SP") || n.Equals("J"))
            {
                curPerson = new Student(curPerson);
                switch (n)
                {
                    case "F":
                        (curPerson as Student).Classification = PersonClassification.Freshman;
                        break;
                    case "SP":
                        (curPerson as Student).Classification = PersonClassification.Sophmore;
                        break;
                    case "J":
                        (curPerson as Student).Classification = PersonClassification.Junior;
                        break;
                    case "S":
                        (curPerson as Student).Classification = PersonClassification.Senior;
                        break;
                }
                
            }

            else
            {
                if(n.Equals("TA"))
                {
                    curPerson = new TeachingAssistant(curPerson);
                }
                else 
                {
                    curPerson = new Instructor(curPerson);
                }
            }
        }
    }
}
